using UnityEngine;
using System.Collections;

public class magiaEnimy2 : MonoBehaviour {

	public float speed;
	private Animator anim;
	private float currentTimeDestroy;
	public float timeDestroy;
	private BoxCollider2D bx2;
	private PlayerBehaviour player;

	void Start () {
		anim = GetComponent<Animator>();
		player = FindObjectOfType(typeof(PlayerBehaviour)) as PlayerBehaviour;
		bx2 = GetComponent<BoxCollider2D>();
	}
	

	void Update () {
		currentTimeDestroy+=Time.deltaTime;
		if(currentTimeDestroy >= timeDestroy)
		{
			Destroy(gameObject);
		}
		Moviment();
	}

	private void Moviment()
	{
		transform.Translate(speed*Time.deltaTime,0,0);
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			bx2.enabled = false;
			player.life-=1;
			speed = 0;
			anim.SetTrigger("hit");
		}
	}

	public IEnumerator DestroyMagia()
	{
		yield return new WaitForSeconds(0);
		Destroy(gameObject);

	}
}
