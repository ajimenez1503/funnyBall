using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class NameScene : MonoBehaviour {

	public Text textName;
	// Use this for initialization
	void Start () {//show the name of the scene in the display
		textName.text = Application.loadedLevelName;
	}
}
