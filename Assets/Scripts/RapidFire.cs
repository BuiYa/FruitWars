using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RapidFire : MonoBehaviour
{

    public GameObject rapidFireItem;

    public float attackRate;
    public float attackRate2;



    // Start is called before the first frame update
    void Start()
    {
        attackRate = PlayerMovement.attackRate;
        attackRate2 = PlayerMovement2.attackRate;
    }

    // Update is called once per frame
    void Update()
    {
        attackRate = PlayerMovement.attackRate;
        attackRate2 = PlayerMovement2.attackRate;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player1")
        {
            if (attackRate > 0.2f)
            {
                FindObjectOfType<PlayerMovement>().RapidFire();
                Destroy(gameObject);
                FindObjectOfType<UIManager>().DisplayRapidText();
                FindObjectOfType<ItemSpawn>().PlayAudio();
            }
        }

        if (other.gameObject.tag == "Player2")
        {
            if (attackRate2 > 0.2f)
            {
                FindObjectOfType<PlayerMovement2>().RapidFire2();
                Destroy(gameObject);
                FindObjectOfType<UIManager>().DisplayRapidText();
                FindObjectOfType<ItemSpawn>().PlayAudio();
            }
        }
    }

}