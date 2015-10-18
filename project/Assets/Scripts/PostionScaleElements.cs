using UnityEngine;
using System.Collections;

public class PostionScaleElements : MonoBehaviour {
	
	//declare all atribute 
	public GameObject board;
	public float ScaleX,ScaleZ;//Scale of the board
	
	public float heightWalls;
	public GameObject WallsHorizontal;
	public GameObject WallsNorth;
	public GameObject WallsSouth;
	
	public GameObject WallsVertical;
	public GameObject WallsWest;
	public GameObject WallsEast;

	public float heightCylinder;
	public GameObject Cylinders;
	public GameObject CylinderA1;
	public GameObject CylinderA2;
	public GameObject CylinderA3;
	public GameObject CylinderA4;


	public GameObject ball;

	public GameObject goal;

	public GameObject bounds;


	public void positionScaleBounds(){
		bounds.transform.localPosition = new Vector3 (0,3f, 0);
		bounds.transform.localScale = new Vector3 (ScaleX + 2, 8f, ScaleZ + 2);
	}

	public void positionscaleGoal(){
		goal.transform.localPosition = new Vector3 ((ScaleX / 2) -2, 0.5f, (ScaleZ/ 2)-5);
		goal.transform.localScale = new Vector3(1.5F, 1F, 1.5F);
	}

	public void postionScaleBall(){
		ball.transform.localPosition = new Vector3 (-(ScaleX / 2) + 1, 1.3f, 0);
		ball.transform.localScale = new Vector3(0.01F, 0.01F, 0.01F);
	}

	public void positionScaleWalls(){
		//walls
		//Horizontal Walls
		WallsHorizontal.transform.localPosition= new Vector3 (0, (heightWalls/2)-0.5F, 0);
		WallsHorizontal.transform.localScale = new Vector3(ScaleX, heightWalls, 1F);
		//North Walls
		float positionZ = (ScaleZ / 2) + 0.5F;
		WallsNorth.transform.localPosition= new Vector3 (0, 0, positionZ);
		WallsNorth.transform.localScale = new Vector3(1, 1, 1);
		//South Walls
		WallsSouth.transform.localPosition= new Vector3 (0, 0, -positionZ);
		WallsSouth.transform.localScale = new Vector3(1, 1, 1);
		//Vertical Walls
		WallsVertical.transform.localPosition= new Vector3 (0, (heightWalls/2)-0.5F, 0);
		WallsVertical.transform.localScale = new Vector3(1, heightWalls, ScaleZ);
		//west walls
		float positionX = (ScaleX / 2) + 0.5F;
		WallsWest.transform.localPosition= new Vector3 (positionX, 0,0 );
		WallsWest.transform.localScale = new Vector3(1, 1, 1);
		//Eeast Walls
		WallsEast.transform.localPosition= new Vector3 (-positionX, 0,0 );
		WallsEast.transform.localScale = new Vector3(1, 1, 1);
	}
	
	public void positionScaleCylinder(){
		//cylinders
		float positionZ = (ScaleZ / 2) + 0.5F;
		float positionX = (ScaleX / 2) + 0.5F;
		Cylinders.transform.localPosition= new Vector3 (0, (heightCylinder)-0.5F, 0);
		Cylinders.transform.localScale = new Vector3(1, heightCylinder, 1);
		
		CylinderA1.transform.localPosition = new Vector3 (positionX, 0, positionZ);
		CylinderA2.transform.localPosition = new Vector3 (-positionX, 0, positionZ);
		CylinderA3.transform.localPosition = new Vector3 (-positionX, 0, -positionZ);
		CylinderA4.transform.localPosition = new Vector3 (positionX, 0, -positionZ);
		
	}
	
	public void positionScaleBoard(){
		//board
		board.transform.localPosition= new Vector3(0, 0, 0);
		board.transform.localScale = new Vector3(ScaleX, 1, ScaleZ);
	}

	
	
	
	// Use this for initialization. 
	//we position and scale the elements of the main board. 
	void Start () {
		positionScaleBoard ();
		positionScaleWalls ();
		positionScaleCylinder ();
		postionScaleBall ();
		positionscaleGoal ();
		positionScaleBounds ();
	}
}

