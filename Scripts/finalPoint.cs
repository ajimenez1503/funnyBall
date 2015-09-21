using UnityEngine;
using System.Collections;


public class finalPoint : MonoBehaviour {

	public GUIText TextWin;
	//public Texture buttonTextureRestart,buttonTextureContinue;
	private bool finish;



	// Use this for initialization
	void Start () {
		finish = false;
		TextWin.text = "";
	}

	void OnGUI() {
		if (finish) {
			GUIStyle myButtonStyle = new GUIStyle(GUI.skin.button);
			myButtonStyle.fontSize = 30;
			if (GUI.Button (new Rect (10, 10, 110, 60), /*buttonTextureRestart*/"Restart",myButtonStyle)) {
				Application.LoadLevel (Application.loadedLevel);
				Debug.Log ("Clicked the button");
			}
			if (GUI.Button (new Rect (10, 90, 110, 60), /*buttonTextureContinue*/"Next",myButtonStyle)) {
				//go to next scene
				//Application.loadedLevel("Scene2");
				Debug.Log ("Clicked the button");
			}
		}
	}

	
	public void win ()
	{
		TextWin.text = "You Win!";
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
