using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement2 : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;

    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode attack;

    public Rigidbody2D rb;

    public Transform groundCheckPoint;
    public bool isGrounded;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    public Animator anim;

    public GameObject fruit;
    public Transform throwPoint;

    public static float attackRate = 0.7f;
    public float nextAttack;

    public int maxHealth = 100;
    public static int currentHealth;
    public HealthBar healthBar;


    public Vector2 originalpos;

    public AudioSource audios;

    // Start is called before the first frame update
    void Start()
    {
        audios = GetComponent<AudioSource>();
        originalpos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);

        if (Input.GetKey(left))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
        else if (Input.GetKey(right))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKeyDown(attack) && Time.time > nextAttack)
        {
            nextAttack = Time.time + attackRate;
            GameObject fruitClone = (GameObject)Instantiate(fruit, throwPoint.position, throwPoint.rotation);
            fruitClone.transform.localScale = transform.localScale;
            anim.SetTrigger("Attack");
            audios.Play();
        }

        if (Input.GetKeyDown(jump) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        anim.SetBool("Grounded", isGrounded);



    }

    public void TakeDamage2(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void LifeReset2()
    {
        currentHealth = 100;
        healthBar.SetHealth(currentHealth);
        FindObjectOfType<UIManager>().DamageP2();
    }

    public void Respawn2()
    {
        gameObject.transform.position = originalpos;
    }

    public void Heal2()
    {
        currentHealth = currentHealth + 20;
        if (currentHealth > 100)
        {
            currentHealth = 100;
        }
        healthBar.SetHealth(currentHealth);
    }

    public IEnumerator RapidFireWait2(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        attackRate = 0.7f;
    }

    public void RapidFire2()
    {
        attackRate = 0.2f;
        StartCoroutine(RapidFireWait2(10));
    }

    public IEnumerator PoisonWait2(float seconds)
    {
        for (int i = 0; i < 9; i++)
        { 
            currentHealth = currentHealth - 2;
            healthBar.SetHealth(currentHealth);
            yield return new WaitForSeconds(seconds);
        }
    }

    public void Poison2()
    {
        StartCoroutine(PoisonWait2(0.5f));
    }
}
