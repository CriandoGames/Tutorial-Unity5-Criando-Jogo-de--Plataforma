using UnityEngine;
using System.Collections;

public class Enimy2 : BaseEnimy {

	public bool isPlayer;
	public bool jump;
	public Transform i;
	public Transform f;
	public float timeShort;
	public GameObject prefabCoin;

	private CircleCollider2D collider2D;
	private bool attack;
	private Rigidbody2D rgd2;
	private GameObject player;
	private float currentTimeShort;
	private Animator anim;
	// Use this for initialization

	void Start () {
		currentTimeShort = timeShort;
		base.Start();
		rgd2 = GetComponent<Rigidbody2D>();
		player = GameObject.FindWithTag("Player");
		anim = GetComponent<Animator>();
		collider2D = GetComponent<CircleCollider2D>();

	}
	
	// Update is called once per frame
	void Update () {
		if(gameController.CurrentState == StateMachine.INGAME)
		{
		LookPlayer();
		Moviment();
		RayCasting();
		Jump();
		Attack();
		}
	}

	private void LookPlayer()
	{

		if(Vector2.Distance(player.transform.position,transform.position) < 2.5f)
		{
			speed = 0;

			attack = true;
			//Debug.Log("Achou o Player");
		}else
		{
			speed = 1.5f;
			attack = false;
		}

		if(Vector2.Distance(player.transform.position,transform.position) < 4.5f)
		  {
			isPlayer = true;
			Debug.Log("Achou o Player");
		 }else
		{
			isPlayer = false;
			Debug.Log("Procurando o Player");
		}
	}

	private void Moviment()
	{
		if(isPlayer)
		{
			if(transform.position.x < player.transform.position.x)
			{
				rgd2.velocity = new Vector3(speed,0,0);
				//transform.localScale = new Vector3(-0.7496531f,0.7496531f,0.7496531f);
				transform.eulerAngles = new Vector3 (0,0,0);
			}else if(transform.position.x > player.transform.position.x)
			{
				rgd2.velocity = new Vector3(-speed,0,0);
				//transform.localScale = new Vector3(0.7496531f,0.7496531f,0.7496531f);
				transform.eulerAngles = new Vector3(0,180,0);
			}


		}
	}

	private void RayCasting()
	{
		if(Physics2D.Linecast(i.position,f.position))
		{
			Debug.Log("Pulo OK");
			jump = true;
		}else
		{
			jump = false;
		}
	}

	private void Jump()
	{
		if(jump && attack == false)
		{
			rgd2.AddForce(new Vector2(0,1000));
		}
	}
	 
	private void Attack()
	{
		anim.SetBool("attack",attack);
		if(attack == true)
		{
			currentTimeShort+=Time.deltaTime;

			if(currentTimeShort >= timeShort && collider2D.enabled == true)
			{
			currentTimeShort = 0;
			Instantiate(prefabMagia,transform.position,transform.rotation);
			}
		
		}

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "shoot")
		{
			Instantiate(prefabCoin,transform.position,transform.rotation);
			collider2D.enabled = false;
			anim.SetTrigger("death");
		}
	}

	IEnumerator DestroyEnimy()
	{


		yield return new WaitForSeconds(0);
		Destroy(gameObject);
	}


}
