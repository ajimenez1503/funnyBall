using UnityEngine;
using System.Collections;

public class finishgame : MonoBehaviour {

	public animationTimer timer;
	public ApplicationPause buttonPause;
	public GUIText TextWin;
	//public Texture buttonTextureRestart,buttonTextureContinue;
	private int finish;//0=not finish 1=win 2=gameover
	
	private float sizeScreenWidth; //width size of screen
	// Use this for initialization
	void Start () {
		finish = 0;
		sizeScreenWidth = Screen.width;
		TextWin.text = "";
	}
	
	void OnGUI() {
		if (finish>0) {
			GUIStyle myButtonStyle = new GUIStyle(GUI.skin.button);
			myButtonStyle.fontSize = 30;
			if(finish==1){
				if (GUI.Button (new Rect (sizeScreenWidth/4, 90, 110, 60), /*buttonTextureRestart*/"Restart",myButtonStyle)) {
					Application.LoadLevel (Application.loadedLevel);
					cleanMenuStart();
				}
				if (GUI.Button (new Rect (sizeScreenWidth*2/4, 90, 110, 60), /*buttonTextureContinue*/"Next",myButtonStyle)) {
					//go to next scene
					//Application.loadedLevel("Scene2");
					cleanMenuStart();
				}
			}
			if(finish==2){
				if (GUI.Button (new Rect (sizeScreenWidth/3, 90, 110, 60),  /*buttonTextureRestart*/"Restart",myButtonStyle)) {
					Application.LoadLevel (Application.loadedLevel);
					cleanMenuStart();
				}
			}

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
		clearPauseTimer ();
		TextWin.text = "You Win!";
		finish = 1;
	}
	public void gameOver()
	{
		clearPauseTimer ();
		TextWin.text = "Game OVer";
		finish = 2;
	}
}