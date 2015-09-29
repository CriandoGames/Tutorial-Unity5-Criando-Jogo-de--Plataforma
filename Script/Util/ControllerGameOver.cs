using UnityEngine;
using System.Collections;

public class ControllerGameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ReturnMenu()
	{
		Application.LoadLevel("Menu");
	}
}

