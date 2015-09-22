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
	void Update () {
		float newAngle;
		if(board.transform.eulerAngles.x > 180)
			newAngle = (board.transform.eulerAngles.x-360);
		else
			newAngle = board.transform.eulerAngles.x;

		newAngle = ( angle);
		Vector3 offsetPos = new Vector3(0, Mathf.Sin ((newAngle)*Mathf.Deg2Rad)*radius, Mathf.Cos ((newAngle)*Mathf.Deg2Rad) * -radius);
		transform.position = player.transform.position + offsetPos;
		transform.eulerAngles = new Vector3(newAngle,0,0);
	}
}
