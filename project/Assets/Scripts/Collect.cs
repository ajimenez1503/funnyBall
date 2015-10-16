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

		goal = finalPoint.GetComponent<BoxCollider>();//get the collider
		goal.enabled = false;//deactive collider

		wrongGoal = wrongFinalPoint.GetComponent<BoxCollider> ();//get the collider
		wrongGoal.enabled = true;//active collider

		pickupPlayer = gameObject.AddComponent<AudioSource> ();//create and setup the sound of pick-up.
		pickupPlayer.playOnAwake = false;
		pickupPlayer.clip = pickUpSound;


		counter.text = "Pickups left : " + count;//set text in the count
	}



	// Update is called once per frame
	void OnTriggerEnter (Collider other) {
		if(other.CompareTag("Pick Up")){
			Destroy(other.gameObject);//delete the pick up
			pickupPlayer.Play();//play the sound
			--count;//update the count
			counter.text = "Pickups left : " + count;
		}

		if (IsFinished ()) {//allow finish the level
			goal.enabled = true;
			wrongGoal.enabled = false;
		}
	}

	//check if there are more pick-up element
	bool IsFinished(){
		return count <= 0;
	}
}
