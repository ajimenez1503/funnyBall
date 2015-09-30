using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class NameScene : MonoBehaviour {

	public Text name;
	// Use this for initialization
	void Start () {
		name.text = Application.loadedLevelName;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
