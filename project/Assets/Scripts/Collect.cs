using UnityEngine;
using System.Collections;

public class Collect : MonoBehaviour {
	public int count;
	public GameObject finalPoint;
	public GameObject pickupPlayer;

	private Collider goal;

	void Start(){
		goal = finalPoint.GetComponent<BoxCollider>();
		goal.enabled = false;
	}



	// Update is called once per frame
	void OnTriggerEnter (Collider other) {
		if(other.CompareTag("Pick Up")){
			other.gameObject.SetActive(false);
			pickupPlayer.GetComponent<AudioSource>().Play();
			--count;
		}

		if (IsFinished())
			goal.enabled = true;
	}

	bool IsFinished(){
		return count <= 0;
	}
}
