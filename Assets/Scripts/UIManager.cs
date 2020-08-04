using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    public int life1;
    public int life2;

    public GameObject p1WinMenu;
    public GameObject p2WinMenu;
    public GameObject TieMenu;

    public GameObject healText;

    public GameObject rapidFireText;

    public GameObject poisonText;

    public GameObject[] p1Health;
    public GameObject[] p2Health;

    public AudioSource audios;

    public GameObject Button;


    // Start is called before the first frame update
    void Start()
    {
        Button.SetActive(false); 
        audios = GetComponent<AudioSource>();
        p1WinMenu.SetActive(false);
        p2WinMenu.SetActive(false);
        TieMenu.SetActive(false);
        healText.SetActive(false);
        rapidFireText.SetActive(false);
        poisonText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(life1<= 0)
        {
            player1.SetActive(false);
            p2WinMenu.SetActive(true);
            Button.SetActive(true);
        }

        if (life2 <= 0)
        {
            player2.SetActive(false);
            p1WinMenu.SetActive(true);
            Button.SetActive(true);
        }

        if (life1 <= 0 && life2 <=0)
        {
            p1WinMenu.SetActive(false);
            p2WinMenu.SetActive(false);
            TieMenu.SetActive(true);
            Button.SetActive(true);
        }

    }

    public void DamageP1()
    {
        life1 -= 1;

        for(int i = 0; i <p1Health.Length; i++)
        {
            if(life1 > i)
            {
                p1Health[i].SetActive(true);
            }
            else
            {
                p1Health[i].SetActive(false);
            }
        }
    }

    public void DamageP2()
    {
        life2 -= 1;

        for (int i = 0; i < p2Health.Length; i++)
        {
            if (life2 > i)
            {
                p2Health[i].SetActive(true);
            }
            else
            {
                p2Health[i].SetActive(false);
            }
        }
    }

    public IEnumerator WaitHealText(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        healText.SetActive(false);
    }

    public void DisplayHealText()
    {
        healText.SetActive(true);
        StartCoroutine(WaitHealText(1f));
    }

    public IEnumerator WaitRapidText(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        rapidFireText.SetActive(false);
    }

    public void DisplayRapidText()
    {
        rapidFireText.SetActive(true);
        StartCoroutine(WaitRapidText(1f));
    }

    public IEnumerator WaitPoisonText(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        poisonText.SetActive(false);
    }

    public void DisplayPoisonText()
    {
        poisonText.SetActive(true);
        StartCoroutine(WaitPoisonText(1f));
    }

    public void PlayAudio()
    {
        audios.Play();
    }

}
