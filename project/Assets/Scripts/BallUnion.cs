using UnityEngine;
using System.Collections;

public class BallUnion : MonoBehaviour {
	public GameObject haloPlayer;//animation light
	public float unionTime;//time to wait for union
	public int id;//id of the duplicator 

	public static int currentID;//current duplicator that you have to use

	private bool ballInside;
	private bool ballInProcess;

	// Use this for initialization
	void Start () {
		ballInside = false;
		ballInProcess = false;
		currentID = -1;//if you dont duplicate the ball
	}

	//when the ball touch the tarjet
	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("ball") && !ballInside && !ballInProcess && (currentID == -1 || currentID == id)) {
			Instantiate(haloPlayer, transform.position, transform.rotation);//create the animation
			other.gameObject.SetActive(false);//deactive the ball
			currentID = id;//update the current duplicator
			StartCoroutine(waitUnion());//wait
		}
	}

	//when the ball go out the tarjet
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
