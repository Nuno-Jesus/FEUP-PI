using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tiro : MonoBehaviour
{
    public GameObject bullet;

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "bullet"){
            Destroy(collision.gameObject);
        }
    }
    void Start(){

    }

    void Update()
    {
        
    }

}
