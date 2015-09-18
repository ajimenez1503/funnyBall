using UnityEngine;
using System.Collections;

public class TransforWalls : MonoBehaviour {

	public GameObject board;

	public GameObject WallsHorizontal;
	public GameObject WallsNorth;
	public GameObject WallsSouth;

	public GameObject WallsVertical;
	public GameObject WallsWest;
	public GameObject WallsEast;

	public GameObject CylinderA1;
	public GameObject CylinderA2;
	public GameObject CylinderA3;
	public GameObject CylinderA4;

	public float ScaleX,ScaleZ;

	// Use this for initialization
	void Start () {
		board.transform.localPosition= new Vector3(0, 0, 0);
		board.transform.localScale = new Vector3(ScaleX, 1, ScaleZ);

		WallsHorizontal.transform.localPosition= new Vector3 (0, 1.5F, 0);
		WallsHorizontal.transform.localScale = new Vector3(ScaleX, 4, 1F);

		float positionZ = (ScaleZ / 2) + 0.5F;
		WallsNorth.transform.localPosition= new Vector3 (0, 0, positionZ);
		WallsNorth.transform.localScale = new Vector3(1, 1, 1);

		WallsSouth.transform.localPosition= new Vector3 (0, 0, -positionZ);
		WallsSouth.transform.localScale = new Vector3(1, 1, 1);

		WallsVertical.transform.localPosition= new Vector3 (0, 1.5F, 0);
		WallsVertical.transform.localScale = new Vector3(1, 4, ScaleZ);

		float positionX = (ScaleX / 2) + 0.5F;
		WallsWest.transform.localPosition= new Vector3 (positionX, 0,0 );
		WallsWest.transform.localScale = new Vector3(1, 1, 1);
		
		WallsEast.transform.localPosition= new Vector3 (-positionX, 0,0 );
		WallsEast.transform.localScale = new Vector3(1, 1, 1);


		CylinderA1.transform.localPosition = new Vector3 (positionX, 0, positionZ);
		CylinderA2.transform.localPosition = new Vector3 (-positionX, 0, positionZ);
		CylinderA3.transform.localPosition = new Vector3 (-positionX, 0, -positionZ);
		CylinderA4.transform.localPosition = new Vector3 (positionX, 0, -positionZ);


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
