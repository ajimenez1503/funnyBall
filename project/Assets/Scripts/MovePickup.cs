using UnityEngine;
using System.Collections;

public class MovePickup : MonoBehaviour {

	public float speed;
	

	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3 (0, speed, 0) * Time.deltaTime);
	}
}
