using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Borracha : MonoBehaviour
{
    private Vector2 startposition = new Vector2(0f, -2.56f);
    private Vector2 endposition = Vector2.zero;
    public GameObject l1;

    public int lifes = 50;
    private float showDuration = 0.5f;
    private int ftime = 60;

    private SpriteRenderer spriteRenderer;

    private bool IsHittable = false;

    public float minHideTime = 0.2f;
    public float maxHideTime = 0.7f;
    public float minShowTime = 0.1f;
    public float maxShowTime = 0.3f;

    private void OnTriggerEnter2D(Collider2D collision)
        
    {   

            if(IsHittable){
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Destroy(l1);
            time.lifes -= 1;
            Debug.Log(time.lifes.ToString());

            if (time.lifes <= 0)
            {
                changeScreen();
            }
        }

               
    }
    public void changeScreen()
    {
        SceneManager.LoadScene("DefeatScreen");
    }

    private IEnumerator ShowHide(Vector2 start, Vector2 end)
    {
        transform.localPosition = start;
        while (ftime > 0)
        {
            float elapsed = 0f;
            float hideTime = Random.Range(minHideTime, maxHideTime);
            while (elapsed < hideTime)
            {
                transform.localPosition = Vector2.Lerp(start, end, elapsed / hideTime);
                elapsed += Time.deltaTime;
                yield return null;
            }

            transform.localPosition = end;

            IsHittable=true;
            float showTime = Random.Range(minShowTime, maxShowTime);
            yield return new WaitForSeconds(showTime);

            elapsed = 0f;
            while (elapsed < showDuration)
            {
                transform.localPosition = Vector2.Lerp(end, start, elapsed / showDuration);
                elapsed += Time.deltaTime;
                yield return null;
            }
            transform.localPosition = start;
            IsHittable=false;
            ftime--;
        }
    }

    private void OnEnable()
    {
        StartCoroutine(ShowHide(startposition, endposition));
    }

    void Update()
    {          

    }
}



