using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ControllerPause : MonoBehaviour {

	public GameObject painelPause;
	private bool isPause;
	private GameController gameController;
	void Start () {
	
		gameController = FindObjectOfType(typeof(GameController)) as GameController;
	}
	
	public void Paused()
	{

		if(isPause == false)
		{
			gameController.CurrentState = StateMachine.PAUSED;
			painelPause.SetActive(true);
			isPause = true;
		}else
		{
			gameController.CurrentState = StateMachine.INGAME;
			painelPause.SetActive(false);
			isPause = false;
		}
	}

}
