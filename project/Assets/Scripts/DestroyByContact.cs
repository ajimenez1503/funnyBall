using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	public Finishgame gameOver;
	public GameObject playerExplosion;
	public float procDuration;
	private bool canGameOver;

	// Use this for initialization
	void Start () {
		canGameOver = false;
	}

	
	// Update is called once per frame
	void Update () {
		if (canGameOver) {//when the wait time finish appear game over
			gameOver.gameOver ();
			canGameOver=false;
		}
		
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "ball")
		{
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			other.gameObject.SetActive(false);
			StartCoroutine(Wait());//wait a specific time to show the explosion
		}
	}

	//wait a specific time
	private IEnumerator Wait()
	{
		canGameOver = false;
		//print(Time.time);
		yield return new WaitForSeconds(procDuration);   //Wait
		//print(Time.time);
		canGameOver = true;//when the wait time finish appear game over

	}
	
	
}
