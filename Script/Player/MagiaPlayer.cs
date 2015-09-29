using UnityEngine;
using System.Collections;

public class MagiaPlayer : MonoBehaviour {

	public float speed;
	private Animator anim;
	private float currentTimeDestroy;
	public float timeDestroy;
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
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
		if(other.gameObject.tag == "Enimy")
		{
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
