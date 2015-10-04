using UnityEngine;
using System.Collections;

public class WrongFinalPoint : MonoBehaviour {
	public AudioClip wrongSound;

	private AudioSource wrong;

	// Use this for initialization
	void Start () {
		wrong = gameObject.AddComponent<AudioSource> ();
		wrong.playOnAwake = false;
		wrong.clip = wrongSound;
	}
	
	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "ball")
		{
			wrong.Play();
		}
	}
}
