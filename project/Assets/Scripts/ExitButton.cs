using UnityEngine;
using System.Collections;

public class ExitButton : MonoBehaviour {
	public Texture buttonTextureExit;
	void OnGUI() {
		GUIStyle myButtonStyle = new GUIStyle(GUI.skin.button);
		myButtonStyle.fontSize = 20;
		if (GUI.Button (new Rect ((Screen.width*2/4) -40, Screen.height*4/5, 80, 80), buttonTextureExit)) {
			//exit game
			Application.Quit();
		}
		if (GUI.Button (new Rect ((Screen.width*1/10) - 55, Screen.height*9/10-30, 110, 60), "MainMenu",myButtonStyle)) {
			//go to MainMenu
			Application.LoadLevel("MainMenu");
		}
	}
}
