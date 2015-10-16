using UnityEngine;
using System.Collections;

public class MoveHammer : MonoBehaviour {

	//declare  atribute 
	public float speed;
	private float gradeZ;
	// Use this for initialization
	public ApplicationPause pause;

	void Start () {
		gradeZ = 0;
	}	
	// Update is called once per frame
	void Update () {
		if (pause!=null && !pause.isPaused ()) {//if not paused
			if (gradeZ > 40) {
				speed = -speed;
			} else if (gradeZ < 0) {
				speed = -speed;
			}
			gradeZ = gradeZ + speed;
			transform.localEulerAngles = new Vector3 (transform.localEulerAngles.x, transform.localEulerAngles.y, gradeZ);
		}		
	}
}
