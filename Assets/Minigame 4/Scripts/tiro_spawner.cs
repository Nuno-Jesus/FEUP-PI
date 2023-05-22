using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tiro_spawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject gun;
    public Text hpText;
    public int lifes = 5;
    public float bulletSpawnDelay = 0.3f;
    public float bulletLifetime = 1.2f;
    public float bulletSpawnOffset = 1.31f;

    private Borracha borracha;

    private void Start()
    {
        InvokeRepeating("SpawnBullet", 0.1f, bulletSpawnDelay);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "hole")
        {
            Destroy(collision.gameObject);
            lifes--;
            hpText.text = lifes.ToString();

            if (lifes <= 0)
            {
                // Player has run out of lives
                Debug.Log("Game Over");
            }
        }
    }

    private void SpawnBullet()
    {
        float spawnPositionX = gun.transform.position.x + bulletSpawnOffset;
        Vector3 spawnPosition = new Vector3(spawnPositionX, -3.5f, 0);
        GameObject newBullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
        Destroy(newBullet, bulletLifetime);
    }
}

