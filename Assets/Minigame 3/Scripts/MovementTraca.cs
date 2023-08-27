using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTraca : MonoBehaviour
{
	public float MoveSpeed;
	public float DeadZonex;
	public float DeadZoney;
	public GameObject TracaDestroyerXPlane;
	public GameObject TracaDestroyerYPlane;
	Collider2D DespawnBoxX;
	Collider2D DespawnBoxY;
	Collider2D tracacol;
	public CaughtTracaScript script;
	private bool moveDown = false;

	// Start is called before the first frame update
	void Start()
	{
		DespawnBoxX = GameObject.FindGameObjectWithTag("DespawnTraca").GetComponent<BoxCollider2D>();
		DespawnBoxY = GameObject.FindGameObjectWithTag("DespawnTracaY").GetComponent<BoxCollider2D>();
		tracacol = GameObject.FindGameObjectWithTag("Tracas").GetComponent<BoxCollider2D>();
		script = GetComponent<CaughtTracaScript>();
		moveDown = true;
	}

	// Update is called once per frame
	void Update()
	{
		if (script.wasCaught)
			return ;
		if (!script.animator.GetCurrentAnimatorStateInfo(0).IsName("CapturedAnim"))
			if (moveDown)
				transform.Translate(Vector3.down * MoveSpeed * Time.deltaTime); // move the object down
		if (transform.position.x > DeadZonex)
			OnTriggerEnter2D(tracacol);
		if (transform.position.y > DeadZoney)
			OnTriggerEnter2D(tracacol);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == DespawnBoxY.tag)
		{
			SpawnTracaScript.aliveTracas--;
			// Debug.Log("Traca destroyed. Alive tracas: " + SpawnTracaScript.aliveTracas);
			Destroy(gameObject);
		}
	}
}
