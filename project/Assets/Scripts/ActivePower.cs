using UnityEngine;
using System.Collections;

public class ActivePower : MonoBehaviour {

	private bool isActive;
	public Material ball_white;
	public Material ball_red;
	public GameObject ball_model;//we need the ball model to associate the different material.

	// Use this for initialization
	void Start () {
		isActive = false;
	}

	//this funtion is called when the ball cross the arch
	void OnTriggerEnter(Collider other) 
	{
		if (other.CompareTag ("ball"))
		{
			isActive=!isActive;//active/deactive the  power
			if(isActive){//chage color
				ball_model.GetComponent<Renderer>().material=ball_red;
			}
			else{
				ball_model.GetComponent<Renderer>().material=ball_white;
			}
		}
	}
	//return if the power is active
	public bool isPowerActive(){
		return isActive;
	}
}
