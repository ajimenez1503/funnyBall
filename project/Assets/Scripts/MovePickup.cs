using UnityEngine;
using System.Collections;

public class MovePickup : MonoBehaviour {
	public float speed;
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (speed, 2*speed, speed));
	}
}
