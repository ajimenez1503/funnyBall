using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	public GameObject player;
	public GameObject board;
	public float radius;
	public float angle;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void LateUpdate () {
		Vector3 offsetPos = new Vector3(0, Mathf.Sin ((angle)*Mathf.Deg2Rad)*radius, Mathf.Cos ((angle)*Mathf.Deg2Rad) * -radius);
		transform.position = player.transform.position + offsetPos;
		transform.eulerAngles = new Vector3(angle,0,0);
	}
}
