using UnityEngine;
using System.Collections;
using System.Linq;
using System;
using System.Collections.Generic;

public class Finishgame : MonoBehaviour {

	public AnimationTimer timer;
	public ApplicationPause buttonPause;
	public GUIText TextWin;

	public AudioClip ambientMusic;
	public AudioClip winningSound;
	public AudioClip gameOverSound;

	//public Texture buttonTextureRestart,buttonTextureContinue;
	private int finish;//0=not finish 1=win 2=gameover

	private AudioSource musicPlayer;
	private AudioSource winMusic;
	private AudioSource gameOverMusic;

	private float sizeScreenWidth; //width size of screen
	// Use this for initialization
	void Start () {
		finish = 0;
		sizeScreenWidth = Screen.width;
		TextWin.text = "";

		winMusic = gameObject.AddComponent<AudioSource> ();
		winMusic.playOnAwake = false;
		winMusic.clip = winningSound;

		gameOverMusic = gameObject.AddComponent<AudioSource> ();
		gameOverMusic.playOnAwake = false;
		gameOverMusic.clip = gameOverSound;

		musicPlayer = gameObject.AddComponent<AudioSource> ();
		musicPlayer.playOnAwake = true;
		musicPlayer.loop = true;
		musicPlayer.clip = ambientMusic;
		musicPlayer.Play ();
	}
	
	void OnGUI() {
		if (finish>0) {
			GUIStyle myButtonStyle = new GUIStyle(GUI.skin.button);
			myButtonStyle.fontSize = 30;
			if(finish==1){
				if (GUI.Button (new Rect (sizeScreenWidth*1/4, 90, 110, 60), /*buttonTextureRestart*/"Restart",myButtonStyle)) {
					Application.LoadLevel (Application.loadedLevel);
					cleanMenuStart();
				}
				if (GUI.Button (new Rect (sizeScreenWidth*2/4, 90, 110, 60), /*buttonTextureContinue*/"Next",myButtonStyle)) {
					//go to next scene
					Application.LoadLevel(nextScene());
					cleanMenuStart();
				}
				if (GUI.Button (new Rect (sizeScreenWidth*3/4, 90, 110, 60), /*buttonTextureContinue*/"Exit",myButtonStyle)) {
					//exit game
					Application.Quit();
				}
			}
			if(finish==2){
				if (GUI.Button (new Rect (sizeScreenWidth/4, 90, 110, 60),  /*buttonTextureRestart*/"Restart",myButtonStyle)) {
					Application.LoadLevel (Application.loadedLevel);
					cleanMenuStart();
				}
				if (GUI.Button (new Rect (sizeScreenWidth*2/4, 90, 110, 60), /*buttonTextureContinue*/"Exit",myButtonStyle)) {
					//exit game
					Application.Quit();
				}
			}

		}
	}

	private string nextScene(){
		int currentScene = Application.loadedLevel;
		currentScene = currentScene + 1;//next scene

		//check if the number scene exits
		if (Application.CanStreamedLevelBeLoaded(currentScene)) {
			return "Scene" + currentScene;//the name the scene
		}//if not exist come back to the first scene. 
		else{
			return "Scene" + 0;
		}
	}



	private void cleanMenuStart(){
		finish = 0;
		TextWin.text = "";
		Time.timeScale = 1;
	}

	private void clearPauseTimer(){
		buttonPause.disapear ();
		timer.Stop ();
		Time.timeScale = 0;
	}
	
	
	public  void win ()
	{
		musicPlayer.Stop ();
		winMusic.Play ();
		clearPauseTimer ();
		TextWin.text = "You Win!";
		finish = 1;
	}
	public void gameOver()
	{
		musicPlayer.Stop ();
		gameOverMusic.Play ();
		clearPauseTimer ();
		TextWin.text = "Game OVer";
		finish = 2;
	}
	public void startPause(){
		musicPlayer.Pause ();
		TextWin.text = "Game paused";
		finish = 2;
	}
	public void finishPause(){
		musicPlayer.Play ();
		finish = 0;
		TextWin.text = "";
	}


	void Update() {
		if (Input.GetKey("escape"))//if you press ESC your game finsih
			Application.Quit();
		
	}
}