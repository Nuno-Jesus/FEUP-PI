using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLarvas : MonoBehaviour
{
    public GameObject Larvas;
    public GameObject Casaco;
    public RestartScript logic;
    Collider2D Circlecollider;
    Collider2D BoxCollider;
    public float spawnRate = 2;
    public float minXLarvas;
    public float maxXLarvas;
    public float minYLarvas;
    public float maxYLarvas;
    private float numoflarvas = 0;
    public SpawnTracaScript script;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<RestartScript>();
        Circlecollider = GameObject.FindGameObjectWithTag("Casaco").GetComponent<CircleCollider2D>();
        BoxCollider = GameObject.FindGameObjectWithTag("Tracas").GetComponent<BoxCollider2D>();
        // Set the sorting order of the Casaco GameObject to a higher value
        SpriteRenderer casacoRenderer = Casaco.GetComponent<SpriteRenderer>();
        casacoRenderer.sortingOrder = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision){
    if (numoflarvas < 10 && script.ContinueGame == true){
        float randomXX, randomYY;
        bool collisionDetected = false;
        do {
            collisionDetected = false;
            randomXX = Random.Range(minXLarvas, maxXLarvas);
            randomYY = Random.Range(minYLarvas, maxYLarvas);
            Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(randomXX, randomYY), 0.5f);
            if (colliders.Length > 0) {
                foreach (Collider2D collider in colliders) {
                    if (collider.gameObject.tag == "Larvas") {
                        collisionDetected = true;
                        break;
                    }
                }
            }
        } while (collisionDetected);

        GameObject newLarva = Instantiate(Larvas, new Vector3(randomXX, randomYY, 0), transform.rotation);
        numoflarvas++;
        // Set the sorting order of the new larva to a higher value
        SpriteRenderer larvaRenderer = newLarva.GetComponent<SpriteRenderer>();
        larvaRenderer.sortingOrder = 2;
        newLarva.tag = "Larvas"; // set tag for larva

        if (numoflarvas == 10){
            Time.timeScale = 0; // stop the game
            logic.GameOverbyLarvas(10);
            script.ContinueGame = false;
            Debug.Log("Game Ended by Larvas. Real Function");
            // Store the number of larvas created
            PlayerPrefs.SetInt("NumOfLarvas", (int)numoflarvas);
            PlayerPrefs.Save();
            numoflarvas = 0;
        } else {
             Debug.Log("Larvas created:" + numoflarvas);
        }
        }
    }
}
