using UnityEngine;
using System.Collections;

public class CheckWins : MonoBehaviour {

	private GameController gameController;
	// Use this for initialization
	void Start () {
	
		gameController = FindObjectOfType(typeof(GameController)) as GameController;	
	
	}
	


	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			if(gameController.contCoin == 5)
			{
				gameController.CurrentState = StateMachine.WINS;
				gameController.Wins();
			}else
			{
				gameController.Fail();
			}
		}
	}
}
