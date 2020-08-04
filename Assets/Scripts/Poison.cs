using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Poison : MonoBehaviour
{

    public GameObject rapidFireItem;




    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player1")
        {
            FindObjectOfType<PlayerMovement>().Poison();
            Destroy(gameObject);
            FindObjectOfType<UIManager>().DisplayPoisonText();
            FindObjectOfType<ItemSpawn>().PlayAudio();
        }


        if (other.gameObject.tag == "Player2")
        {
            FindObjectOfType<PlayerMovement2>().Poison2();
            Destroy(gameObject);
            FindObjectOfType<UIManager>().DisplayPoisonText();
            FindObjectOfType<ItemSpawn>().PlayAudio();
        }
    }

}