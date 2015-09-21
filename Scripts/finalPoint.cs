using UnityEngine;
using System.Collections;


public class finalPoint : MonoBehaviour {

	public GUIText TextWin;
	
	private bool finish;



	// Use this for initialization
	void Start () {
		finish = false;
		TextWin.text = "";
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	
	public void win ()
	{
		TextWin.text = "you win";
		finish = true;
	}
	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "ball")
		{
			win ();
		}
	}

}
