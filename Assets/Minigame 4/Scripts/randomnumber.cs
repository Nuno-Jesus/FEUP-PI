using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class randomnumber : MonoBehaviour
{   
    public Text rndnumb;
    public static int randomNumber;
    // Start is called before the first frame update
    void Start()
    {
        System.Random rnd = new System.Random();
        randomNumber = rnd.Next(0,9);
		rndnumb.text = null;
        rndnumb.text = randomNumber.ToString();
    }

    public void n1() {
        Code.code += randomNumber;
    }
    public void n2() {
        Code.code += randomNumber;
    }
    public void n3() {
        Code.code += randomNumber;
    }
    public void n4() {
        Code.code += randomNumber;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}