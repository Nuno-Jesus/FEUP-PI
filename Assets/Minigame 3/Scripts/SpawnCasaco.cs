using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCasaco : MonoBehaviour
{
    public GameObject Casaco;
    public float X;
    public float Y;
    // Start is called before the first frame update
    void Start()
    {
        spawnCasaco();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnCasaco(){
        Instantiate(Casaco, new Vector3(X, Y, 0), transform.rotation);
    }
}
