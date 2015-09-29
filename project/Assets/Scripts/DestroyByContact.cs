﻿using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	public finishgame gameOver;
	public GameObject playerExplosion;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "ball")
		{
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			gameOver.gameOver ();
			other.gameObject.SetActive(false);
		}
	}

}