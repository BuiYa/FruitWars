using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealItem : MonoBehaviour
{

    public GameObject healItem;

    public int currentHealth;
    public int currentHealth2;



    // Start is called before the first frame update
    void Start()
    {
        currentHealth = PlayerMovement.currentHealth;
        currentHealth2 = PlayerMovement2.currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = PlayerMovement.currentHealth;
        currentHealth2 = PlayerMovement2.currentHealth;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player1")
        {
            if (currentHealth < 100)
            {
                FindObjectOfType<PlayerMovement>().Heal();
                Destroy(gameObject);
                FindObjectOfType<UIManager>().DisplayHealText();
                FindObjectOfType<ItemSpawn>().PlayAudio();
            }
        }

        if (other.gameObject.tag == "Player2")
        {
            if (currentHealth2 < 100)
            {
                FindObjectOfType<PlayerMovement2>().Heal2();
                Destroy(gameObject);
                FindObjectOfType<UIManager>().DisplayHealText();
                FindObjectOfType<ItemSpawn>().PlayAudio();
            }
        }
    }

}
