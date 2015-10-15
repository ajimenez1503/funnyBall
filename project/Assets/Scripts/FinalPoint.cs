using UnityEngine;
using System.Collections;


public class FinalPoint : MonoBehaviour {

	public Finishgame menu;
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
