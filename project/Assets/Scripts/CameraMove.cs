using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	public GameObject player;
	public float radius;
	public float angle;
	private Vector3 offsetPos;

	void Start(){
		offsetPos = new Vector3(0, Mathf.Sin ((angle)*Mathf.Deg2Rad)*radius, Mathf.Cos ((angle)*Mathf.Deg2Rad) * -radius);
	}

	// LateUpdate is called after all Update functions have been called.
	void LateUpdate () {
		transform.position = player.transform.position + offsetPos;//move the position of the camera associate to the position of the ball
		transform.eulerAngles = new Vector3(angle,0,0);//only move the camera in the X angle
	}
}
