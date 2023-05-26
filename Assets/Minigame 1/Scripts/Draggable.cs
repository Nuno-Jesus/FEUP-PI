using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Draggable : MonoBehaviour
{
    public int score = 0;

    public int targetScore = 50;

    public GameManager game_manager;

    public GameObject FloatingScoreBusto;
    public GameObject FloatingScoreRelógio;
    public GameObject FloatingScoreArma;
    public GameObject FloatingScoreQuadro;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Busto")
        {
            score += 10;
            Destroy(collision.gameObject);
            GameObject floatingScore = Instantiate(FloatingScoreBusto, transform.position, Quaternion.identity);
            Destroy(floatingScore, 1f);
        }

        if (collision.tag == "Relógio")
        {
            score += 5;
            Destroy(collision.gameObject);
            GameObject floatingScore = Instantiate(FloatingScoreRelógio, transform.position, Quaternion.identity);
            Destroy(floatingScore, 1f);
        }

        if (collision.tag == "Arma")
        {
            Destroy(collision.gameObject);
        }

        if (collision.tag == "Quadro")
        {
            score += 1;
            Destroy(collision.gameObject);
            GameObject floatingScore = Instantiate(FloatingScoreQuadro, transform.position, Quaternion.identity);
            Destroy(floatingScore, 1f);
        }

        if (collision.tag == "Casaco")
        {
            Destroy(collision.gameObject);
        }

        if (collision.tag == "Chapéu")
        {
            Destroy(collision.gameObject);
        }

        if (collision.tag == "Cinto")
        {
            Destroy(collision.gameObject);
        }

        if(score >= targetScore)
        {
            game_manager.StopSpawning();
            changeScreen2();
        }
    }

    public void changeScreen2()
    {
		OrientationController.setPortraitView();
        SceneManager.LoadScene("VictoryScreen");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
