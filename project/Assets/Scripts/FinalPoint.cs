using UnityEngine;
using System.Collections;


public class FinalPoint : MonoBehaviour {

	public Finishgame menu;
	//if the ball arrive to hte final point
	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "ball")
		{
			menu.win();
		}
	}

}
