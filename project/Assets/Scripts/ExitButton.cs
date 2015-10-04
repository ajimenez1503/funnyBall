using UnityEngine;
using System.Collections;

public class ExitButton : MonoBehaviour {
	public Texture buttonTextureExit;
	void OnGUI() {
			if (GUI.Button (new Rect ((Screen.width*2/4) -40, Screen.height*4/5, 80, 80), buttonTextureExit)) {
				//exit game
				Application.Quit();
			}
	}
}
