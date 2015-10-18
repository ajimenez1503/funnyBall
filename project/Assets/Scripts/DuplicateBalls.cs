using UnityEngine;
using System.Collections;

public class DuplicateBalls : MonoBehaviour {
	public GameObject ball1;
	public GameObject ball2;
	public GameObject target1;
	public GameObject target2;
	public float duplicationTime;
	public GameObject haloPlayer;//animation light


	private bool teleported;
	private bool ballInside;

	void Start(){
		teleported = false;
		ballInside = false;
	}

	void Update(){
		if (teleported) {
			//move the two balls to new position
			ball1.transform.position = new Vector3(target1.transform.position.x, target1.transform.position.y, target1.transform.position.z);
			ball2.transform.position = new Vector3(target2.transform.position.x, target2.transform.position.y, target2.transform.position.z);

			//create the animation light
			Instantiate(haloPlayer, target1.transform.position, target1.transform.rotation);
			Instantiate(haloPlayer, target2.transform.position, target2.transform.rotation);

			//set the speed of the second ball equal of the first
			ball2.GetComponent<Rigidbody>().velocity = ball1.GetComponent<Rigidbody>().velocity;

			ball1.SetActive(true);
			ball2.SetActive(true);

			teleported = false;
		}
		//check if the both balls are in the both tarjet.
		if (target1.GetComponent<BallUnion> ().isActivated () && target2.GetComponent<BallUnion> ().isActivated ()) {
			ballInside = true;
			//change the positon of the first ball
			ball1.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
			Instantiate(target1.GetComponent<BallUnion>().haloPlayer, transform.position, transform.rotation);
			ball1.SetActive(true);//only active the first ball
			target1.GetComponent<BallUnion> ().processFinished();
			target2.GetComponent<BallUnion> ().processFinished();
		}
	}


	//when you touch the collider
	void OnTriggerEnter(Collider other){
		//the ball enter in the duplicator
		if (other.CompareTag ("ball") && !ballInside) {
			ball1.SetActive(false);
			ball2.SetActive(false);
			Instantiate(haloPlayer, transform.position, transform.rotation);

			target1.GetComponent<BallUnion>().putBallInside();
			target2.GetComponent<BallUnion>().putBallInside();

			StartCoroutine(waitDuplicate());
		}
	}
	//when you go out the collider
	void OnTriggerExit(Collider other){
		if (other.CompareTag ("ball")) {
			ballInside = false;
		}
	}

	private IEnumerator waitDuplicate(){
		yield return new WaitForSeconds (duplicationTime);
		teleported = true;
	}
}

