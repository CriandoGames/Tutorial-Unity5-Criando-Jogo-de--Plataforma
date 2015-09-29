using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {
	private float inputH;
	public float speed=2;
	private Animator anim;
	private  Rigidbody2D rgd2;
	public Transform ground;
	public float timeShoot; 
	public Transform prefabMagia;
	public int life;

	private bool canMove = true;
	private float currentTimeShoot;
	private bool isGround;
	private GameController gamecontroller;
	public GameObject armaPlayer;
	// Use this for initialization
	void Start () {

		life = 3;
		gamecontroller = FindObjectOfType(typeof(GameController)) as GameController;
		rgd2 = GetComponent<Rigidbody2D>();
		anim = GetComponentInChildren<Animator>();
		currentTimeShoot = timeShoot;
	}

	void FixedUpdate () {
		if(gamecontroller.CurrentState == StateMachine.INGAME)
		{
#if !UNITY_ANDROID && !UNITY_IPHONE

			Moviment(Input.GetAxisRaw("Horizontal"));
#else
			Moviment(inputH);

#endif

			Shooting(0);
			Jump(0);
		}

	}

	public void Moviment(float inputHorizontal)
	{
			
	
		isGround = Physics2D.Linecast(transform.position,ground.position,1 << LayerMask.NameToLayer("Ground"));

		//mexendo com a rotacao do Sprite
		if(inputHorizontal < 0 )
		{
			transform.Translate(Vector2.right * speed * Time.deltaTime);
			anim.SetFloat("Walk",Mathf.Abs(inputHorizontal));
			transform.eulerAngles = new Vector2(0,180);

		}else
			if(inputHorizontal > 0  )
		   {
			transform.Translate(Vector2.right * speed * Time.deltaTime);
			anim.SetFloat("Walk",Mathf.Abs(inputHorizontal));
			transform.eulerAngles = new Vector2(0,0);
		   }

		if(inputHorizontal == 0)
		{
			inputH = 0;
			anim.SetFloat("Walk",0);
		}

	}

	public void Normalize(float inputHorizontal)
	{
		inputH = inputHorizontal;
	}


	private void Jump(float start)
	{
#if !UNITY_ANDROID && !UNITY_IPHONE
		if(isGround != false && Input.GetKey(KeyCode.Space))
		{

			anim.SetBool("Jump",!isGround);
			//canMove = isGround;
			rgd2.AddForce(Vector2.up * 100);
		}else
		{
			//canMove = isGround;
			anim.SetBool("Jump",!isGround);

		}
#else

		if(isGround != false && start==1)
		{
			
			anim.SetBool("Jump",!isGround);

			rgd2.AddForce(Vector2.up * 500);
		}else
		{

			anim.SetBool("Jump",!isGround);
			
		}

#endif

	}


	public void Shooting(float start)
	{

		currentTimeShoot += Time.deltaTime;

#if !UNITY_ANDROID && !UNITY_IPHONE
			if(Input.GetMouseButtonDown(0))
			{
				if(currentTimeShoot > timeShoot)
				{
				Instantiate(prefabMagia,armaPlayer.transform.position,transform.rotation);
					currentTimeShoot = 0;
				}
			}
#else
		if(start == 1)
		{
		if(currentTimeShoot > timeShoot)
		{
			Instantiate(prefabMagia,armaPlayer.transform.position,transform.rotation);
			currentTimeShoot = 0;
		}
		}
#endif


	}









}
