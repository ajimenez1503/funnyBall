using UnityEngine;
using System.Collections;

public class DestroyByBounds : MonoBehaviour {


	public Finishgame gameOver;

	//when a object is out of bounds, game over
	void OnTriggerExit(Collider other)
	{
		gameOver.gameOver ();
	}

}

