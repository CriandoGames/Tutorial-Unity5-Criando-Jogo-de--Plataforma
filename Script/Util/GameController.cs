using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public enum StateMachine{

	STARTGAME,
	INGAME,
	PAUSED,
	GAMEOVER,
	WINS
}

public class GameController : MonoBehaviour {

	public Sprite[] spriteLife;
	public Image imgLife;
	private StateMachine stateMachine; //Variavel da maquina de estado
	private PlayerBehaviour player;
	private Vector3 newPosition;
	public int contCoin;
	public Text txtCount;
	public GameObject PainelWins;
	public GameObject controllerMobile;
	void Start () {
#if !UNITY_ANDROID && !UNITY_IPHONE
		controllerMobile.SetActive(false);
#endif
		stateMachine = StateMachine.STARTGAME;
		player = FindObjectOfType(typeof(PlayerBehaviour)) as PlayerBehaviour;
	}
	
	// Update is called once per frame
	void Update () {
		currentStateMachine();
	}

	private void currentStateMachine()
	{
		switch(stateMachine)
		{
		case StateMachine.STARTGAME:
		{
			StartGame();
		}break;
		case StateMachine.INGAME:
		{
			CheckLifePlayer();
		}break;
		case StateMachine.PAUSED:
		{
			
		}break;
		case StateMachine.GAMEOVER:
		{
			
		}break;
		case StateMachine.WINS:
		{
			
		}break;
		}
	}
	//funcao Set In Get
		public StateMachine CurrentState{
		get{return stateMachine;}
		set{stateMachine = value;}}
	//funcao SartGame
	public void StartGame()
	{
		newPosition = player.transform.position;
		CurrentState = StateMachine.INGAME;
	}

	public void CheckLifePlayer()
	{
		if(player.life == 1)
		{
			imgLife.sprite = spriteLife[0];
		}
		else
		if(player.life == 2)
		{
			imgLife.sprite = spriteLife[1];
		}else if(player.life == 3)
		{
			imgLife.sprite = spriteLife[2];
		}
		else
		{
			Debug.Log("Gamer Over");
			Application.LoadLevel("GameOver");
		}
	}
	public void Fail()
	{

		player.transform.position = newPosition;

	}

	public void Wins()
	{
		PainelWins.SetActive(true);
	}
}
