using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Code : MonoBehaviour
{
	public Text number;
	public static string code = "";
	public static int n1 = 0;
	public static int n2 = 0;
	public static int n3 = 0;
	public static int n4 = 0;
	// Start is called before the first frame update
	void Start()
	{
		number.text = n1.ToString();
		n1 = n2 = n3 = n4 = 0;
	}

	public void increaseNumber1()
	{
		if (n1 == 9)
			n1 = 0;
		else
			n1 += 1;
		number.text = n1.ToString();
	}

	public void decreaseNumber1()
	{
		if (n1 == 0)
			n1 = 9;
		else
			n1 -= 1;
		number.text = n1.ToString();
	}

	public void increaseNumber2()
	{
		if (n2 == 9)
			n2 = 0;
		else
			n2 += 1;
		number.text = n2.ToString();
	}

	public void decreaseNumber2()
	{
		if (n2 == 0)
			n2 = 9;
		else
			n2 -= 1;
		number.text = n2.ToString();
	}

	public void increaseNumber3()
	{
		if (n3 == 9)
			n3 = 0;
		else
			n3 += 1;
		number.text = n3.ToString();
	}

	public void decreaseNumber3()
	{
		if (n3 == 0)
			n3 = 9;
		else
			n3 -= 1;
		number.text = n3.ToString();
	}

	public void increaseNumber4()
	{
		if (n4 == 9)
			n4 = 0;
		else
			n4 += 1;
		number.text = n4.ToString();
	}

	public void decreaseNumber4()
	{
		if (n4 == 0)
			n4 = 9;
		else
			n4 -= 1;
		number.text = n4.ToString();
	}

	public void checkCode()
	{
		string checker = n1.ToString() + n2.ToString() + n3.ToString() + n4.ToString();
		
		if (checker == code)
			SceneManager.LoadScene("Abrir_cofre2");
		else
			time.lifes--;

		if (time.lifes <= 0)
		{
			time.resetTimer();
			SceneManager.LoadScene("DefeatScr");
		}
	}
	// Update is called once per frame
}
