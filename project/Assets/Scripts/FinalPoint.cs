using UnityEngine;
using System.Collections;


public class finalPoint : MonoBehaviour {

	public finishgame menu;
	// Use this for initialization
	void Start () {
	}
	
	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "ball")
		{
			menu.win();
		}
	}

}
