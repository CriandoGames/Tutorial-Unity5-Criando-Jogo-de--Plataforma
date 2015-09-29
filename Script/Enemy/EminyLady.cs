using UnityEngine;
using System.Collections;

public class EminyLady : BaseEnimy {
	//publicos 
	public float timeChange;
	public float timeShot;
	public Transform distance;
	public Transform distanceBegin;

	//privados 
	private float currentTimeChange;
	private bool isRight;
	private float currentTimeShot;
	private bool isPlayer;

	// Use this for initialization
	void Start () {
		base.Start();
		isRight = false;
	}
	
	// Update is called once per frame
	void Update () {

		if(gameController.CurrentState == StateMachine.INGAME)
		{
			Moviment();
			RayCast();

		}

	}

	private void Moviment()
	{
		currentTimeChange+=Time.deltaTime;
		currentTimeShot+=Time.deltaTime;

		if(currentTimeChange >= timeChange)
		{

			if(isRight == false)
			{
			transform.eulerAngles = new Vector2(0,180);
				isRight = true;
			}else
			{
			transform.eulerAngles = new Vector2(0,0);
				isRight = false;
			}
			currentTimeChange=0;
		}

		transform.Translate(-speed*Time.deltaTime,0,0);

	}

	private void RayCast()
	{
		Debug.DrawLine(distanceBegin.position,distance.position,Color.red);
		isPlayer = Physics2D.Linecast(distanceBegin.position,distance.position,1 << LayerMask.NameToLayer("Player"));

		if(isPlayer && currentTimeShot > timeShot)
		{
			Debug.Log("Achou o Player");
			Instantiate(prefabMagia,transform.position,transform.rotation);
			currentTimeShot = 0;
		}
	}












}
