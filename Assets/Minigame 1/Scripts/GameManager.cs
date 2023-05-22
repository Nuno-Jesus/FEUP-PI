using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject arma_prefab;
    public GameObject casaco_prefab;
    public GameObject relogio_prefab;
    public GameObject cinto_prefab;
    public GameObject chapeu_prefab;
    public GameObject quadro_prefab;
    public GameObject busto_prefab;
    public Draggable player_script;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnCinto", 1, 4);
        InvokeRepeating("SpawnChapeu", 1, 5);
        InvokeRepeating("SpawnQuadro", 2, 5);
        InvokeRepeating("SpawnCasaco", 3, 6);
        InvokeRepeating("SpawnArma", 6, 7);
        InvokeRepeating("SpawnRelogio", 9, 8);
        InvokeRepeating("SpawnBusto", 12, 10);
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void SpawnArma()
    {
        float tempPos = Random.Range(-8f, 8f);
        Instantiate(arma_prefab, new Vector3(tempPos, 4f, 0), Quaternion.identity);
    }

    void SpawnCasaco()
    {
        float tempPos = Random.Range(-8f, 8f);
        Instantiate(casaco_prefab, new Vector3(tempPos, 4f, 0), Quaternion.identity);
    }

    void SpawnRelogio()
    {
        float tempPos = Random.Range(-8f, 8f);
        Instantiate(relogio_prefab, new Vector3(tempPos, 4f, 0), Quaternion.identity);
    }

    void SpawnCinto()
    {
        float tempPos = Random.Range(-7f, 7f);
        Instantiate(cinto_prefab, new Vector3(tempPos, 4f, 0), Quaternion.identity);
    }

    void SpawnChapeu()
    {
        float tempPos = Random.Range(-8f, 8f);
        Instantiate(chapeu_prefab, new Vector3(tempPos, 4f, 0), Quaternion.identity);
    }

    void SpawnQuadro()
    {
        float tempPos = Random.Range(-7f, 7f);
        Instantiate(quadro_prefab, new Vector3(tempPos, 4f, 0), Quaternion.identity);
    }

    void SpawnBusto()
    {
        float tempPos = Random.Range(-8f, 8f);
        Instantiate(busto_prefab, new Vector3(tempPos, 4f, 0), Quaternion.identity);
    }

    public void StopSpawning()
    {
        CancelInvoke();
    }
}
