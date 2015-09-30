using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class animationTimer : MonoBehaviour {

	public int timeToComplete;
	public Image timer;
	public finishgame finish;

	private float timeLeft;
	private bool stop;
	
	// Use this for initialization
	void Start () {
		timeLeft = 1.0f;
		stop = false;
	}

	void Update(){
		if (!stop) {
			timeLeft -= Time.deltaTime * 1.0f / timeToComplete;
			timer.fillAmount = timeLeft;
			if (IsFinished ()) {
				finish.gameOver ();
			}
		}



	}

	public bool IsFinished(){
		return timeLeft <= 0;
	}

	public void Stop(){
		stop = true;
		timer.fillAmount = 0;
	}

	public void Continue(){
		stop = false;
	}

}
