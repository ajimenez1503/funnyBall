using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CircularProgress : MonoBehaviour {

	public int timeToComplete;
	public Image timer;
	public finishgame finish;

	private float timeLeft;
	private bool isPaused;
	
	// Use this for initialization
	void Start () {
		timeLeft = 1.0f;
		isPaused = false;
	}

	void Update(){
		if (!isPaused) {
			timeLeft -= Time.deltaTime * 1.0f / timeToComplete;

			timer.fillAmount = timeLeft;
		}

		if (IsFinished ()) {
			finish.gameOver ();
		}

	}

	public bool IsFinished(){
		return timeLeft <= 0;
	}

	public void Pause(){
		isPaused = true;
	}

	public void Continue(){
		isPaused = false;
	}

}
