using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;

public class SpawnTracaScript : MonoBehaviour
{
	public GameObject traca;
	public GameObject Larvas;
	public GameObject Casaco;
	public RestartScript logic;
	public float spawnRate = 2;
	private float timer;
	private float numberofTracas;
	private float numoflarvas;
	public float minX;
	public float maxX;
	public float minY;
	public float maxY;
	public int TracasEscaped = 0;
	public bool ContinueGame = true;
	public const int MAXTRACAS = MAXSCORE + OFFSET;
	public const int MAXSCORE = 40;
	public const int OFFSET = 2;
	public int numoflarvas1;
	// Start is called before the first frame update

	void Start()
	{
		logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<RestartScript>();
		Spawntraca();
		numberofTracas = 0;
		SpriteRenderer casacoRenderer = Casaco.GetComponent<SpriteRenderer>();
		casacoRenderer.sortingOrder = 1;
	}

	// Update is called once per frame
	void Update()
	{
		if (timer < spawnRate)
			timer += Time.deltaTime;
		else if (ContinueGame == true)
		{
			timer = 0;
			numberofTracas++;
			// Debug.Log("Spawned tracas: " + numberofTracas);
			Spawntraca();
		}
	}

	void Spawntraca()
	{
		float randomX, randomY;
		bool collisionDetected;
		do
		{
			collisionDetected = false;
			randomX = Random.Range(minX, maxX);
			randomY = Random.Range(minY, maxY);
			Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(randomX, randomY), 0.5f);
			if (colliders.Length > 0)
			{
				foreach (Collider2D collider in colliders)
				{
					if (collider.gameObject.tag == "Tracas")
					{
						collisionDetected = true;
						break;
					}
				}
			}
		} while (collisionDetected);

		GameObject newTraca = Instantiate(traca, new Vector3(randomX, randomY, 0), transform.rotation);
		newTraca.tag = "Tracas"; // set tag for traca

		// Set the sorting layer and order of the traca sprite renderer
		SpriteRenderer tracaRenderer = newTraca.GetComponent<SpriteRenderer>();
		tracaRenderer.sortingLayerName = "Background";
		tracaRenderer.sortingOrder = -1;

		// Check if game should end
		if (numberofTracas == MAXTRACAS)
		{
			logic.GameOver(logic.playerScore);
			PlayerPrefs.SetInt("Score", logic.playerScore);
			PlayerPrefs.Save();
			ContinueGame = false;
		}
	}
}