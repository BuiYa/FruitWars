using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    public GameObject[] itemPrefab;

    public Vector2 center;
    public Vector2 size;

    public AudioSource audios;


    // Start is called before the first frame update
    void Start()
    {
        audios = GetComponent<AudioSource>();
        InvokeRepeating("SpawnItem", 3.0f, 6.0f); // spawns item after 3 seconds every 6 seconds
    }

    // Update is called once per frame
    void Update()
    {
   
    }

    public void SpawnItem()
    {
        Vector2 pos = center + new Vector2(UnityEngine.Random.Range(-size.x / 2, size.x / 2), UnityEngine.Random.Range(-size.y / 2, size.y / 2));
        int randItem = UnityEngine.Random.Range(0, itemPrefab.Length);
        Instantiate(itemPrefab[randItem], pos, Quaternion.identity);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }

    public void PlayAudio()
    {
        audios.Play();
    }

}
