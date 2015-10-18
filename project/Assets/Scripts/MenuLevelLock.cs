using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuLevelLock : MonoBehaviour {

	enum TypeLock { LOCK=0, UNLOCK=1}; //0= lock and 1=unlock
	private int nLevel;//number of level
	public List<GameObject> levelCollider=new List<GameObject>();
	public List<GUITexture> levelLocked = new List<GUITexture>();
	public List<GUITexture> levelUnlocked=new List<GUITexture>();

	//initialize the PlayerPrefs
	private void initializePlayerPrefs(){
		//star in scene1 because scene0 will be unlock always
		for (int level = 1; level < nLevel; level++){
			//create a PlayerPrefs of that particular level and set it's to TypeLock.LOCK=0
			if(!PlayerPrefs.HasKey("SavedLevel"+level.ToString())){//if no key of that name exists
				PlayerPrefs.SetInt("SavedLevel"+level.ToString(),(int)TypeLock.LOCK);
				//create a atribute which will be changed in playerPrefs and initialize to TypeLock.LOCK=0
			}
		}
	}

	//initialize the level unlock and lock
	private void initializeLockLevel(){
		if(levelCollider.Count != 0 && levelLocked.Count != 0 && levelUnlocked.Count != 0){//not empty
			for (int level = 0; level < nLevel; level++){
				if(level==0){//leve0 unlock by default
					levelUnlocked[level].enabled = true;
					levelLocked[level].enabled = false;
					levelCollider[level].SetActive(true);
				}
				else{
					levelUnlocked[level].enabled = false;
					levelLocked[level].enabled = true;
					levelCollider[level].SetActive(false);
				}
			}
		}
	}


	// Use this for initialization
	void Start () {
		nLevel = levelLocked.Count;
		initializePlayerPrefs();
		initializeLockLevel();
	}
	
	// Update is called once per frame
	void Update () {
		for (int level = 1; level < nLevel; level++){
			//check the value of PlayerPrefs
			if(PlayerPrefs.HasKey("SavedLevel"+level.ToString())){
				if((int)TypeLock.UNLOCK==PlayerPrefs.GetInt("SavedLevel"+level.ToString())){//1==unlock
					levelUnlocked[level].enabled = true;
					levelLocked[level].enabled = false;
					levelCollider[level].SetActive(true);
				}
			}
		}

		//check the click of mouse on a level
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition); //typical mouse click input
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)){
				for (int level = 0; level < nLevel; level++){
					if(hit.collider.name == "Level"+level.ToString()+"Collider"){ //this is all of our code for triggering loading levels when a collider is clicked on
						Application.LoadLevel("Scene"+level.ToString());
					}
				}
			}
		}	
	}

	//add button 
	void OnGUI() {
		GUIStyle myButtonStyle = new GUIStyle(GUI.skin.button);
		myButtonStyle.fontSize = 30;
		if (GUI.Button (new Rect ((Screen.width*1/4) - 55, Screen.height*3/4, 110, 60),"Reset",myButtonStyle)) {
			PlayerPrefs.DeleteAll();//delete PlayerPrefs and update the scene
			//restart levels
			Application.LoadLevel("MainMenu");
		}
		if (GUI.Button (new Rect ((Screen.width*2/4) - 55, Screen.height*3/4, 110, 60),"Credits",myButtonStyle)) {
			//go to credits
			Application.LoadLevel("Credits");
		}
		if (GUI.Button (new Rect ((Screen.width*3/4) - 55, Screen.height*3/4, 110, 60),"Exit",myButtonStyle)) {
			//exit game
			Application.Quit();
		}
	}
}
