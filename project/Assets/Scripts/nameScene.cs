using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class NameScene : MonoBehaviour {

	public Text textName;
	// Use this for initialization
	void Start () {
		textName.text = Application.loadedLevelName;
	}
}
