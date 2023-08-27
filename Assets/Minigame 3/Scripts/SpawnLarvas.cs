using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLarvas : MonoBehaviour
{
	public GameObject Larvas;
	public GameObject Casaco;
	public RestartScript logic;
	public float spawnRate = 2;
	public float minXLarvas;
	public float maxXLarvas;
	public float minYLarvas;
	public float maxYLarvas;
	private float numoflarvas = 0;
	public SpawnTracaScript script;

	void Start()
	{
		logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<RestartScript>();
		SpriteRenderer casacoRenderer = Casaco.GetComponent<SpriteRenderer>();
		casacoRenderer.sortingOrder = 1;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (numoflarvas < 10 && script.ContinueGame == true)
		{
			float randomXX, randomYY;
			bool collisionDetected;

			do
			{
				collisionDetected = false;
				randomXX = Random.Range(minXLarvas, maxXLarvas);
				randomYY = Random.Range(minYLarvas, maxYLarvas);
				Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(randomXX, randomYY), 0.5f);
				if (colliders.Length > 0)
				{
					foreach (Collider2D collider in colliders)
					{
						if (collider.gameObject.tag == "Larvas")
						{
							collisionDetected = true;
							break;
						}
					}
				}
			} while (collisionDetected);

			GameObject newLarva = Instantiate(Larvas, new Vector3(randomXX, randomYY, 0), transform.rotation);
			numoflarvas++;
			Debug.Log("Number of larvas: " + numoflarvas);

			// Set the sorting order of the new larva to a higher value
			SpriteRenderer larvaRenderer = newLarva.GetComponent<SpriteRenderer>();
			larvaRenderer.sortingOrder = 2;
			newLarva.tag = "Larvas";

			if (numoflarvas == 10)
			{
				Time.timeScale = 0;
				logic.GameOverbyLarvas(10);
				script.ContinueGame = false;
				PlayerPrefs.SetInt("NumOfLarvas", (int)numoflarvas);
				PlayerPrefs.Save();
				numoflarvas = 0;
			}
		}
	}
}
