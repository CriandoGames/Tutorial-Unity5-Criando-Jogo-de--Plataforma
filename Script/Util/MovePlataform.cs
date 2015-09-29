using UnityEngine;
using System.Collections;

public class MovePlataform : MonoBehaviour {
	public float speed;
	private GameController gameController;
	// Use this for initialization
	void Start () {
		gameController = FindObjectOfType(typeof(GameController)) as GameController;
	}
	
	// Update is called once per frame
	void Update () {
		if(gameController.CurrentState == StateMachine.INGAME)
		{
		moviment();
	    }
	}

	void moviment()
	{
		transform.Translate(0,speed*Time.deltaTime,0);
	}
	      
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "limite")
		{
			Debug.Log("Plataforma chegou ao limite");
			speed*=-1;
		}
	}
}
