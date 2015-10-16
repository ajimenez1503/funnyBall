using UnityEngine;
using System.Collections;

public class MoveBoard : MonoBehaviour {
	
	public float speed;
	public GameObject ball1;
	public GameObject ball2 = null;
	private float rotX;
	private float rotZ;
	
	
	
	// Use this for initialization
	void Start () {
		//initialice rotation initial
		rotX = 0;
		rotZ = 0;

		//deactive the ball 2
		if(ball2 == null){
			ball2 = new GameObject();
			ball2.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		//when you press the arroy of keyboard move the angle
		if (Input.GetKey (KeyCode.UpArrow)) {
			rotX += speed;
		} else if (Input.GetKey (KeyCode.DownArrow)) {
			rotX -= speed;
		}else if (Input.GetKey (KeyCode.RightArrow)) {
			rotZ -= speed;
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			rotZ += speed;
		}

		//we adjust certain limits. The limits is +/-45 grades
		if (rotX >= 45) {
			rotX = 45;
		} else if (rotX <= -45) {
			rotX = -45;
		}
		if (rotZ >= 45) {
			rotZ = 45;
		} else if (rotZ <= -45) {
			rotZ = -45;
		}

		//move the board the rotation choose
		if(ball1.activeSelf || ball2.activeSelf)
			transform.eulerAngles = new Vector3 (rotX, 0, rotZ);
	}
}
