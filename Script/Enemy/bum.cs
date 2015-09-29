using UnityEngine;
using System.Collections;

public class bum : MonoBehaviour {

	private Animator anim;
	private PlayerBehaviour player;
	void Start () {
		anim = GetComponent<Animator>();
		player = FindObjectOfType(typeof(PlayerBehaviour)) as PlayerBehaviour;
	}
	
	void OnCollisionEnter2D(Collision2D other)
	{

		anim.SetTrigger("bum");
		if(other.gameObject.tag == "Player")
		{
			player.life-=1;
		}
	
	}

	IEnumerator DestroyGameObject()
	{
		yield return new WaitForSeconds(1);
		Destroy(gameObject);

	}
}
