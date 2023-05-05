using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GroundController : MonoBehaviour
{
    public int EndgameLife = 3;

    public Draggable player_script;
    public GameManager game_manager;
    public GameObject l1, l2, l3;

    public AudioSource audioArma;
    public AudioSource audioBusto;
    public AudioSource audioCasaco;
    public AudioSource audioChapéu;
    public AudioSource audioCinto;
    public AudioSource audioQuadro;
    public AudioSource audioRelógio;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Casaco")
        {
            Destroy(collision.gameObject);
            audioCasaco.Play();
        }

        if (collision.tag == "Chapéu")
        {
            Destroy(collision.gameObject);
            audioChapéu.Play();
        }

        if (collision.tag == "Cinto")
        {
            Destroy(collision.gameObject);
            audioCinto.Play();
        }

        if (collision.tag == "Busto")
        {
            Destroy(collision.gameObject);
            EndgameLife -= 1;
            player_script.score -= 5;
            audioBusto.Play(); 
        }

        if (collision.tag == "Relógio")
        {
            Destroy(collision.gameObject);
            EndgameLife -= 1;
            player_script.score -= 3;
            audioRelógio.Play(); 
        }

        if (collision.tag == "Arma")
        {
            Destroy(collision.gameObject); 
            audioArma.Play();
        }

        if (collision.tag == "Quadro")
        {
            Destroy(collision.gameObject);
            EndgameLife -= 1;
            player_script.score -= 1;
            audioQuadro.Play(); 
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void changeScreen()
    {
        SceneManager.LoadScene("DefeatScreen");
    }

    // Update is called once per frame
    void Update()
    {
        switch(EndgameLife)
        {
            case 0: 
                l1.SetActive(false);
                l2.SetActive(false);
                l3.SetActive(false);
                break;
            case 1:
                l1.SetActive(true);
                l2.SetActive(false);
                l3.SetActive(false);
                break;
            case 2:
                l1.SetActive(true);
                l2.SetActive(true);
                l3.SetActive(false);
                break;
            case 3:
                l1.SetActive(true);
                l2.SetActive(true);
                l3.SetActive(true);
                break;
            default:
                l1.SetActive(false);
                l2.SetActive(false);
                l3.SetActive(false);
                break;
        }
        if(EndgameLife <= 0)
        {
            game_manager.StopSpawning();
            changeScreen();
        }
    }
}
