using UnityEngine;
using System.Collections;

public class ApplicationPause : MonoBehaviour {


	public Finishgame finishmenu;
	private bool paused;
	public Texture buttonTexture;
	private bool appear;



	// Use this for initialization. 
	void Start(){
		paused = false;
		appear = true;
		Time.timeScale = 1;

	}

	//show the pause/play button
	void OnGUI() {
		if (appear) {
			if (GUI.Button (new Rect (20, Screen.height-125, 50, 50), buttonTexture)) {//if the player do click
				if (paused) {//play the fame
					Time.timeScale = 1;//play the game
					paused = false;
					finishmenu.finishPause();//disappear the menu of pause
				} else {
					Time.timeScale = 0;//pause the game
					paused = true;
					finishmenu.startPause();//appear the menu of pause
				}
			}
		}
	}
	//Put off the button of play/pause
	public void disapear(){
		appear = false;
	}

	public bool isPaused(){
		return paused;
	}
}