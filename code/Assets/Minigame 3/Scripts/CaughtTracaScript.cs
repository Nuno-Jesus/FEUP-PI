using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaughtTracaScript : MonoBehaviour
{
	public bool wasCaught;
	public bool isCaught;
	public RestartScript logic;
	public int playerScore;
	Collider2D col;
	private AudioSource source;
	public AudioClip destroySound; // sound effect to play when the object is destroyed
	public Animator animator; // reference to the Animator component

	// Start is called before the first frame update
	void Start()
	{
		source = GameObject.FindGameObjectWithTag("Tracas").GetComponent<AudioSource>();
		logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<RestartScript>();
		col = GetComponent<Collider2D>();
		isCaught = false;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.touchCount <= 0)
			return ;
			
		Touch touch = Input.GetTouch(0);
		Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
		if (touch.phase == TouchPhase.Began)
		{
			Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
			if (col == touchedCollider)
			{
				wasCaught = true;
				source.PlayOneShot(destroySound);
				animator.SetBool("Is_Alive", true);
				isCaught = true;
				col.enabled = false; // disable the box collider
										//animation.Play("CapturedAnim"); // play the animation here
			}
		}
		if (touch.phase == TouchPhase.Ended)
			if (wasCaught)
				StartCoroutine(WasCaught());
	}

	private IEnumerator WasCaught()
	{
		animator.SetBool("Is_Alive", false);

		 // wait for animation to finish playing
		yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
		Destroy(gameObject);
		logic.addScore();
	}
}
