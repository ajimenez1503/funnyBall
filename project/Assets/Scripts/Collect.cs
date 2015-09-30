using UnityEngine;
using System.Collections;

public class Collect : MonoBehaviour {
	public int count;
	public GameObject finalPoint;
	public AudioClip pickUpSound;


	private AudioSource pickupPlayer;
	private Collider goal;

	void Start(){
		goal = finalPoint.GetComponent<BoxCollider>();
		goal.enabled = false;

		pickupPlayer = gameObject.AddComponent<AudioSource> ();
		pickupPlayer.playOnAwake = false;
		pickupPlayer.clip = pickUpSound;
	}



	// Update is called once per frame
	void OnTriggerEnter (Collider other) {
		if(other.CompareTag("Pick Up")){
			other.gameObject.SetActive(false);
			pickupPlayer.Play();
			--count;
		}

		if (IsFinished())
			goal.enabled = true;
	}

	bool IsFinished(){
		return count <= 0;
	}
}
