using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;


public class tiro_spawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject gun;

    public AudioSource somerr;

    public float bulletSpawnDelay = 0.3f;
    public float bulletLifetime = 1.2f;

    private Borracha borracha;

    private void Start()
    {   
        InvokeRepeating("SpawnBullet", 0.1f, bulletSpawnDelay);
        
    }

    private void SpawnBullet()
    {

        float spawnPositionX = gun.transform.position.x;
        Vector3 spawnPosition = new Vector3(spawnPositionX, -3.5f, 0);
        GameObject newBullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
        Destroy(newBullet, bulletLifetime);
    }
}

