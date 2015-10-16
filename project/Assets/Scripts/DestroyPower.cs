using UnityEngine;
using System.Collections;

public class DestroyPower : MonoBehaviour {

	public ActivePower power;
	public GameObject playerExplosion;
	
	void OnTriggerEnter (Collider other) {
		//when the ball touch the brick and the power is active, create explosion and destroy brik
		if (power.isPowerActive() && other.CompareTag ("BrickRed")) {
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			Destroy(other.gameObject);
		}
	}

}
