using UnityEngine;
using System.Collections;

public class BallUnion : MonoBehaviour {
	public GameObject haloPlayer;
	public float unionTime;
	public int id;

	public static int currentID;

	private bool ballInside;
	private bool ballInProcess;

	// Use this for initialization
	void Start () {
		ballInside = false;
		ballInProcess = false;
		currentID = -1;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("ball") && !ballInside && !ballInProcess && (currentID == -1 || currentID == id)) {
			Instantiate(haloPlayer, transform.position, transform.rotation);
			other.gameObject.SetActive(false);
			currentID = id;
			StartCoroutine(waitUnion());
		}
	}

	void OnTriggerExit(Collider other){
		if (other.CompareTag ("ball")) {
			ballInside = false;
		}
	}

	public void putBallInside(){
		ballInside = true;
	}

	public bool isActivated(){
		return ballInProcess;
	}

	public void processFinished(){
		ballInProcess = false;
		currentID = -1;
	}

	private IEnumerator waitUnion(){
		yield return new WaitForSeconds (unionTime);
		ballInProcess = true;
	}
}
