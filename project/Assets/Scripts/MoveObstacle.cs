using UnityEngine;
using System.Collections;

public class MoveObstacle : MonoBehaviour {

	//declare all atribute 
	public GameObject obstacle;
	public GameObject board;
	public float speed;

	private float positionX,positionZ,scaleBoardZ;
	private bool initialize;

	// Use this for initialization
	void Start () {
		initialize = false;
		//find out the scale and postion of board

	}
	
	// Update is called once per frame
	void Update () {
		//initilice only the firts frame
		if (!initialize) {
			positionX=obstacle.transform.localPosition.x;
			scaleBoardZ=board.transform.localScale.z;
			initialize=true;
		}
		positionZ = obstacle.transform.localPosition.z;
		if (positionZ > (scaleBoardZ) / 4.0f) {
			speed=-speed;
		}
		else if(positionZ < -(scaleBoardZ) / 4.0f){
			speed=-speed;
		}
		positionZ = positionZ + speed;
		obstacle.transform.localPosition= new Vector3(positionX, 1, positionZ);
	
	}
}
