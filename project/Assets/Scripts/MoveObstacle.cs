using UnityEngine;
using System.Collections;

public class MoveObstacle : MonoBehaviour {

	//declare all atribute 
	public GameObject obstacle;
	public float speed;

	private float positionX,positionZ;
	private bool initialize;
	public Finishgame finish;

	// Use this for initialization
	void Start () {
		positionX = obstacle.transform.localPosition.x;

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (finish != null && finish.isNotFinish ()) {//if not paused
			positionZ = obstacle.transform.localPosition.z + speed;//change the position of the obstacle
			obstacle.transform.localPosition = new Vector3 (positionX, 1, positionZ);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Wall")
		{
			speed = -speed;
		}
	}
}
