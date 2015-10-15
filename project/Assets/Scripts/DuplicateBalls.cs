using UnityEngine;
using System.Collections;

public class DuplicateBalls : MonoBehaviour {
	public GameObject ball1;
	public GameObject ball2;
	public GameObject cible1;
	public GameObject cible2;
	public float duplicationTime;
	public GameObject haloPlayer;


	private bool changed;
	private bool ballInside;

	void Start(){
		changed = false;
		ballInside = false;
	}

	void Update(){
		if (changed) {
			ball1.transform.position = new Vector3(cible1.transform.position.x, cible1.transform.position.y, cible1.transform.position.z);
			ball2.transform.position = new Vector3(cible2.transform.position.x, cible2.transform.position.y, cible2.transform.position.z);


			Instantiate(haloPlayer, cible1.transform.position, cible1.transform.rotation);
			Instantiate(haloPlayer, cible2.transform.position, cible2.transform.rotation);

			ball2.GetComponent<Rigidbody>().velocity = ball1.GetComponent<Rigidbody>().velocity;

			ball1.SetActive(true);
			ball2.SetActive(true);

			changed = false;
		}
		if (cible1.GetComponent<BallUnion> ().isActivated () && cible2.GetComponent<BallUnion> ().isActivated ()) {
			ballInside = true;
			ball1.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
			Instantiate(cible1.GetComponent<BallUnion>().haloPlayer, transform.position, transform.rotation);
			ball1.SetActive(true);
			cible1.GetComponent<BallUnion> ().processFinished();
			cible2.GetComponent<BallUnion> ().processFinished();
		}
	}
	
	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("ball") && !ballInside) {
			ball1.SetActive(false);
			ball2.SetActive(false);
			Instantiate(haloPlayer, transform.position, transform.rotation);

			cible1.GetComponent<BallUnion>().putBallInside();
			cible2.GetComponent<BallUnion>().putBallInside();

			StartCoroutine(waitDuplicate());
		}
	}

	void OnTriggerExit(Collider other){
		if (other.CompareTag ("ball")) {
			ballInside = false;
		}
	}

	private IEnumerator waitDuplicate(){
		yield return new WaitForSeconds (duplicationTime);
		changed = true;
	}
}

