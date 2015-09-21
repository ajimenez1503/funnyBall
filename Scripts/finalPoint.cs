using UnityEngine;
using System.Collections;


public class finalPoint : MonoBehaviour {

	public GUIText TextWin;
	//public Texture buttonTextureRestart,buttonTextureContinue;
	private bool finish;

	private float sizeScreenWidth; //width size of screen


	// Use this for initialization
	void Start () {
		finish = false;
		sizeScreenWidth = Screen.width;
		TextWin.text = "";
	}

	void OnGUI() {
		if (finish) {
			GUIStyle myButtonStyle = new GUIStyle(GUI.skin.button);
			myButtonStyle.fontSize = 30;
			if (GUI.Button (new Rect (sizeScreenWidth/4, 90, 110, 60), /*buttonTextureRestart*/"Restart",myButtonStyle)) {
				Application.LoadLevel (Application.loadedLevel);
				finish = false;
				TextWin.text = "";
			}
			if (GUI.Button (new Rect (sizeScreenWidth*2/4, 90, 110, 60), /*buttonTextureContinue*/"Next",myButtonStyle)) {
				//go to next scene
				//Application.loadedLevel("Scene2");
				finish = false;
				TextWin.text = "";
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
			win();
		}
	}

}
