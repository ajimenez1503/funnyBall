using UnityEngine;
using System.Collections;

public class MovePickup : MonoBehaviour {
	public float speed;
	
	// Update is called once per frame
	void Update () {//animate the pick-up elemetns
		transform.Rotate (new Vector3 (speed, 2*speed, speed));
	}
}
