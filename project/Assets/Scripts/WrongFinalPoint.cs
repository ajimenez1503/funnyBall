using UnityEngine;
using System.Collections;

public class WrongFinalPoint : MonoBehaviour {
	public AudioClip wrongSound;

	private AudioSource wrong;

	// Use this for initialization
	void Start () {
		wrong = gameObject.AddComponent<AudioSource> ();//associate and set-up sound
		wrong.playOnAwake = false;
		wrong.clip = wrongSound;
	}

	//if the ball arrived the final point and not pick-up all elemtns, play a wrong sound 
	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "ball")
		{
			wrong.Play();
		}
	}
}
