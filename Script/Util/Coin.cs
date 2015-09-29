using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {
	private GameController gameController;
	// Use this for initialization
	void Start () {
	
		gameController = FindObjectOfType(typeof(GameController)) as GameController;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			gameController.contCoin+=1;
			gameController.txtCount.text = gameController.contCoin.ToString();
			Destroy(gameObject);
		}
	}

}
