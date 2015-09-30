using UnityEngine;
using System.Collections;

public class Teletransport : MonoBehaviour {
	public GameObject cross;
	private float procDuration;
	private bool changed;
	private GameObject player;
	// Use this for initialization
	void Start () {
		procDuration = 0.7f;
		changed = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (changed) {
			player.transform.localPosition = new Vector3 (cross.transform.localPosition.x, player.transform.localPosition.y, cross.transform.localPosition.z);
			player.SetActive (true);
			changed=false;
		}

	}
	
	void OnTriggerEnter(Collider other) 
	{
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
		yield return new WaitForSeconds(procDuration);   //Wait
		//print(Time.time);
		changed = true;//when the wait time finish appear game over
		
	}



}
