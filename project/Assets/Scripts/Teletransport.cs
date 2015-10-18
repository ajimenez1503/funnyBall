using UnityEngine;
using System.Collections;

public class Teletransport : MonoBehaviour {
	public GameObject cross;
	private float timeTeletransport;
	private bool teleported;
	private GameObject player;
	// Use this for initialization
	void Start () {
		timeTeletransport = 0.7f;
		teleported = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (teleported) {//if the ball is teleported, we changed the position
			player.transform.position = new Vector3 (cross.transform.position.x, cross.transform.position.y + 1.2f, cross.transform.position.z);
			player.SetActive (true);
			teleported=false;
		}
	}
	
	void OnTriggerEnter(Collider other) 
	{
		//when the ball touch the teletransport
		if (other.tag == "ball")
		{
			player=other.gameObject;
			player.gameObject.SetActive(false);
			StartCoroutine(Wait());//wait a specific time to show the explosion
		}
	}

	//wait a specific time
	private IEnumerator Wait()
	{
		//print(Time.time);
		yield return new WaitForSeconds(timeTeletransport);   //Wait
		//print(Time.time);
		teleported = true;//when the wait time finish appear game over
	}



}
