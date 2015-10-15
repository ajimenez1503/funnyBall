using UnityEngine;
using System.Collections;

public class EnableFire : MonoBehaviour {
	public GameObject fires;
	public GameObject player;
	// Use this for initialization
	void Start () {
		fires.SetActive(false);
	}
	
	void Update(){
		if(!GetComponent<BoxCollider> ().bounds.Contains (player.transform.position))
			fires.SetActive(false);
	}

	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("ball")) {
			fires.SetActive (true);
		}
	}
}
