using UnityEngine;
using System.Collections;

public class ApplicationPause : MonoBehaviour {

	private bool paused;
	public Texture buttonTexture;
	private bool appear;


	// Use this for initialization. 
	void Start(){
		paused = false;
		appear = true;
	}
	
	void OnGUI() {
		if (appear) {
			if (GUI.Button (new Rect (20, 470, 50, 50), buttonTexture)) {
				if (paused) {
					Time.timeScale = 1;
					paused = false;
				} else {
					Time.timeScale = 0;
					paused = true;
				}
			}
			if (paused) {
				GUIStyle myLabelStyle = new GUIStyle (GUI.skin.label);
				myLabelStyle.fontSize = 30;
				GUI.Label (new Rect (90, 450, 100, 100), "Game paused", myLabelStyle);
			}
		}
	}

	public void disapear(){
		appear = false;
	}


}