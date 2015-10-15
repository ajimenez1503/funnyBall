using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;
using System;
using System.Collections.Generic;

public class Finishgame : MonoBehaviour {

	public AnimationTimer timer;
	public ApplicationPause buttonPause;
	public Text TextWin;

	public AudioClip ambientMusic;
	public AudioClip winningSound;
	public AudioClip gameOverSound;

	//public Texture buttonTextureRestart,buttonTextureContinue;
	private int finish;//0=not finish 1=win 2=gameover

	private AudioSource musicPlayer;
	private AudioSource winMusic;
	private AudioSource gameOverMusic;

	// Use this for initialization
	void Start () {
		finish = 0;
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

	private void UnLockNextScene(){
<<<<<<< HEAD
		int CurrentScene = Application.loadedLevel -1;//because scene0 start en level 1
		CurrentScene = CurrentScene + 1;
		print ("unlock scene" + CurrentScene);
		if(PlayerPrefs.HasKey("SavedLevel"+CurrentScene.ToString())){//if the key exists already
			PlayerPrefs.SetInt ("SavedLevel"+CurrentScene.ToString(), 1);
		}

=======
		int CurrentScene = Application.loadedLevel;
		CurrentScene = CurrentScene + 1;
		print ("unlock scene" + CurrentScene);
		PlayerPrefs.SetInt ("SavedLevel"+CurrentScene.ToString(), 1);
>>>>>>> 8172abea3ed608dd274286889318746fee256e15
	}
	
	void OnGUI() {
		if (finish>0) {
			GUIStyle myButtonStyle = new GUIStyle(GUI.skin.button);
			myButtonStyle.fontSize = 30;
			if(finish==1){
				if (GUI.Button (new Rect ((Screen.width*1/4) - 55, Screen.height/2, 110, 60), /*buttonTextureRestart*/"Restart",myButtonStyle)) {
					Application.LoadLevel (Application.loadedLevel);
					cleanMenuStart();
				}
				if (GUI.Button (new Rect ((Screen.width*2/4) - 55, Screen.height/2, 110, 60), /*buttonTextureContinue*/"Next",myButtonStyle)) {
					//go to next scene
					UnLockNextScene();
					Application.LoadLevel("MainMenu");
					cleanMenuStart();
				}
				if (GUI.Button (new Rect ((Screen.width*3/4) - 55, Screen.height/2, 110, 60), /*buttonTextureContinue*/"Exit",myButtonStyle)) {
					//exit game
					Application.Quit();
				}
			}
			if(finish==2){
				if (GUI.Button (new Rect ((Screen.width*1/4) - 55, Screen.height/2, 110, 60),  /*buttonTextureRestart*/"Restart",myButtonStyle)) {
					Application.LoadLevel (Application.loadedLevel);
					cleanMenuStart();
				}
				if (GUI.Button (new Rect ((Screen.width*2/4) - 55, Screen.height/2, 110, 60), /*buttonTextureContinue*/"Exit",myButtonStyle)) {
					//exit game
					Application.Quit();
				}
				myButtonStyle.fontSize = 20;
				if (GUI.Button (new Rect ((Screen.width*3/4) - 55, Screen.height/2, 110, 60), /*buttonTextureContinue*/"MainMenu",myButtonStyle)) {
					Application.LoadLevel("MainMenu");
					cleanMenuStart();
				}
			}

		}
	}
	/*
	private string nextScene(){
		int currentScene = Application.loadedLevel;
		currentScene = currentScene + 1;//next scene

		//check if the number scene exits and if the scene is the last
		if (Application.CanStreamedLevelBeLoaded(currentScene) && Application.CanStreamedLevelBeLoaded(currentScene+1) ) {
				return "Scene" + currentScene;//the name the scene
		}//if it is the las, go to credits
		else{
			return "Credits";
		}
	}
	*/


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