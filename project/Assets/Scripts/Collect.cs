using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Collect : MonoBehaviour {
	public int nbPickups;
	public GameObject finalPoint;
	public GameObject wrongFinalPoint;
	public AudioClip pickUpSound;
	public Text counter;

	public static int count; // when there are two balls, we have to share this number

	private AudioSource pickupPlayer;
	private Collider goal;
	private Collider wrongGoal;


	void Start(){
		if (nbPickups >= 0) // in the second ball, we put -1 pickups so it doesn't change
			count = nbPickups;

		goal = finalPoint.GetComponent<BoxCollider>();
		goal.enabled = false;

		wrongGoal = wrongFinalPoint.GetComponent<BoxCollider> ();
		wrongGoal.enabled = true;

		pickupPlayer = gameObject.AddComponent<AudioSource> ();
		pickupPlayer.playOnAwake = false;
		pickupPlayer.clip = pickUpSound;


		counter.text = "Pickups left : " + count;
	}



	// Update is called once per frame
	void OnTriggerEnter (Collider other) {
		if(other.CompareTag("Pick Up")){
			other.gameObject.SetActive(false);
			pickupPlayer.Play();
			--count;

			counter.text = "Pickups left : " + count;
		}

		if (IsFinished ()) {
			goal.enabled = true;
			wrongGoal.enabled = false;
		}
	}

	bool IsFinished(){
		return count <= 0;
	}
}
