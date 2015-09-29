using UnityEngine;
using System.Collections;

public class Collect : MonoBehaviour {
	public int count;
	public GameObject finalPoint;

	private Collider goal;

	void Start(){
		goal = finalPoint.GetComponent<BoxCollider>();
		goal.enabled = false;
	}



	// Update is called once per frame
	void OnTriggerEnter (Collider other) {
		if(other.CompareTag("Pick Up")){
			other.gameObject.SetActive(false);
			--count;
		}

		if (IsFinished())
			goal.enabled = true;
	}

	bool IsFinished(){
		return count <= 0;
	}
}
