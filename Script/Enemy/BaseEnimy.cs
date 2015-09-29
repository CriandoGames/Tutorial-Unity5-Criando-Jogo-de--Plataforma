using UnityEngine;
using System.Collections;

public class BaseEnimy : MonoBehaviour {
	public float speed=2.0f;
	public GameObject prefabMagia;
	protected GameController gameController;
	// Use this for initialization
	protected void Start () {
	gameController = FindObjectOfType(typeof(GameController)) as GameController;

	}

}
