using UnityEngine;
using System.Collections;

public class ExitScene : MonoBehaviour {


	private GameObject player;
	private Vector3 postionStart;
	void Start () {
	
		player = GameObject.FindWithTag("Player");
		postionStart = player.transform.position;
	}
	


	// verificar se o player esta dentro do cenario
	void OnTriggerEnter2D(Collider2D other)
	{

		if(other.gameObject.tag == "Player")
		{
			player.GetComponent<PlayerBehaviour>().life-=1;
			Debug.Log("Player Left Scene");
			player.transform.position = postionStart;
		}
	}

}
