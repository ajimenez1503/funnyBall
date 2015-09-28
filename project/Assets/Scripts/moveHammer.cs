using UnityEngine;
using System.Collections;

public class moveHammer : MonoBehaviour {

	//declare all atribute 
	public float speed;
	private float gradeZ;
	// Use this for initialization
	void Start () {
		gradeZ = 0;
		
	}
	
	// Update is called once per frame
	void Update () {

		if (gradeZ > 40) {
			speed=-speed;
		}
		else if(gradeZ < 0){
			speed=-speed;
		}
		gradeZ = gradeZ + speed;
		//transform.localRotation = new Quaternion.Euler (0, 0, gradeZ);
		transform.localEulerAngles = new Vector3 (0, 0, gradeZ);
		
	}
}
