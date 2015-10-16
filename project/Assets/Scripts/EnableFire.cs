using UnityEngine;
using System.Collections;

public class EnableFire : MonoBehaviour {
	public GameObject fires;
	public GameObject player;
	// Use this for initialization
	void Start () {
		fires.SetActive(false);//initilize the fire as deactive
	}
	
	void Update(){
		if(!GetComponent<BoxCollider> ().bounds.Contains (player.transform.position))//check if your are outside of the room
			fires.SetActive(false);
	}

	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("ball")) {//if the ball enter in the room, the fire is active.
			fires.SetActive (true);
		}
	}
}
