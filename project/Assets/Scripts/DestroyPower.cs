using UnityEngine;
using System.Collections;

public class DestroyPower : MonoBehaviour {

	public ActivePower power;
	public GameObject playerExplosion;
	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerEnter (Collider other) {
		if (power.isPowerActive() && other.CompareTag ("BrickRed")) {
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			Destroy(other.gameObject);
		}
	}
}
