using UnityEngine;
using System.Collections;

public class ActivePower : MonoBehaviour {

	private bool isActive;
	public Material ball_white;
	public Material ball_red;
	public GameObject ball_model;
	// Use this for initialization
	void Start () {
		isActive = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "ball")
		{
			isActive=!isActive;//active power
			if(isActive){//chage color
				ball_model.GetComponent<Renderer>().material =ball_red;
			}
			else{
				ball_model.GetComponent<Renderer>().material =ball_white;
			}


		}
	}
	public bool isPowerActive(){
		return isActive;
	}
}
