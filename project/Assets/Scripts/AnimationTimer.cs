using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AnimationTimer : MonoBehaviour {

	public int timeToComplete;//total time of the scene
	public Image timer;
	public Finishgame finish;

	private float timeLeft;//part of the image that you show.
	private bool stop;
	
	// Use this for initialization
	void Start () {
		timeLeft = 1.0f; //star 1, then nothing shown full Image
		stop = false;
	}

	void Update(){
		if (!stop) {
			timeLeft -= Time.deltaTime * 1.0f / timeToComplete;
			timer.fillAmount = timeLeft;
			if (IsFinished ()) {//if the time is finish, we call gameover
				finish.gameOver ();
			}
		}
	}

	//return if the time is finished
	public bool IsFinished(){
		return timeLeft <= 0;
	}

	//stop the timer
	public void Stop(){
		stop = true;
		timer.fillAmount = 0; //fillAmount=0 nothing show
	}

	//continue the timer 
	public void Continue(){
		stop = false;
	}

}
