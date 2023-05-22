using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class randomnumber : MonoBehaviour
{   
    public Text rndnumb;
    // Start is called before the first frame update
    void Start()
    {
        int randomNumber;
        System.Random rnd = new System.Random();
        randomNumber = rnd.Next(1,10);
        rndnumb.text = randomNumber.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
