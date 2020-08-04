﻿using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class ThrowObject2 : MonoBehaviour
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
        health = PlayerMovement.currentHealth;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player1")
        {
            FindObjectOfType<PlayerMovement>().TakeDamage(10);
            FindObjectOfType<UIManager>().PlayAudio();
            if (health <= 10)
            {
                FindObjectOfType<PlayerMovement>().LifeReset();
                FindObjectOfType<PlayerMovement>().Respawn();
            }
        }

        if (other.tag == "Environment" || other.tag == "Player1")
        {
            Destroy(gameObject);
        }

    }
}
