using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class ThrowObject : MonoBehaviour
{
    public float throwForce;

    public Rigidbody2D rbThrow;

    private static int health;


    // Start is called before the first frame update
    void Start()
    {
        rbThrow = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rbThrow.velocity = new Vector2(throwForce * transform.localScale.x, 0);
        health = PlayerMovement2.currentHealth;
    }



    void OnTriggerEnter2D(Collider2D other)
    {   
        if (other.tag == "Player2")
        {
            FindObjectOfType<PlayerMovement2>().TakeDamage2(10);
            FindObjectOfType<UIManager>().PlayAudio();
            if (health <= 10)
            {
                FindObjectOfType<PlayerMovement2>().LifeReset2();
                FindObjectOfType<PlayerMovement2>().Respawn2();
            }
        }
        
        if(other.tag == "Environment" || other.tag == "Player2")
        {
            Destroy(gameObject);
        }

    }
}
