using UnityEngine;
using System.Collections;

public class TesteInimigo : MonoBehaviour {


	public bool nearPlayer;
	public float speed;
	public Transform begin;
	public Transform end;
	public bool jump;

	private GameObject player;
	private Rigidbody2D rgd2;
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
		rgd2 = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
		LookPlayer();
		FollowPlayer();
		RayCasting();
		Jump();
	}

	private void LookPlayer()
	{
		if(Vector2.Distance(transform.position,player.transform.position)< 2.5f)
		{
			speed =0;
			nearPlayer = true;
			Debug.Log("Achou o Player");
		}else
		{
			speed = 1.5f;
		}

		if(Vector2.Distance(transform.position,player.transform.position)< 5)
		{
			nearPlayer = true;
			Debug.Log("Achou o Player");
		}
		else
		{
			nearPlayer = false;
			Debug.Log("Procurando Player");
		}

	}
	private void FollowPlayer()
	{
		if(nearPlayer)
		{

			if(player.transform.position.x < transform.position.x)
			{

				rgd2.velocity= new Vector3(-speed,0,0);
				//transform.eulerAngles = new Vector2(0,180);
				transform.localScale = new Vector3(-0.8186486f,0.8186486f,1);
			}

			if(player.transform.position.x > transform.position.x)
			{
				rgd2.velocity= new Vector3(speed,0,0);
				//transform.eulerAngles = new Vector2(0,0);
				transform.localScale = new Vector3(-0.8186486f,0.8186486f,1);
			}
		}

	}

	private void RayCasting()

	{

		Debug.DrawLine(begin.position,end.position,Color.red);

		if(Physics2D.Linecast(begin.position,end.position))
		{
			jump = true;
		}else
		{
			jump = false;
		}

	}

	private void Jump()
	{
		if(jump)
		{
		rgd2.velocity = new Vector3(0,40,0);
		}
	}
}
