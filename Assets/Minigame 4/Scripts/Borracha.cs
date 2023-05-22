using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Borracha : MonoBehaviour
{
    public GameObject vida;

    private Vector2 startposition = new Vector2(0f, -2.56f);
    private Vector2 endposition = Vector2.zero;

    private float showDuration = 0.5f;
    private int ftime = 60;

    private SpriteRenderer spriteRenderer;

    private bool IsHittable = false;

    public float minHideTime = 0.1f;
    public float maxHideTime = 0.3f;
    public float minShowTime = 1f;
    public float maxShowTime = 1.3f;

    private void OnCollisionEnter2D(Collision2D other)
    {   if(IsHittable){
            Destroy(gameObject);
            Destroy(vida);
        }
        
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
}



