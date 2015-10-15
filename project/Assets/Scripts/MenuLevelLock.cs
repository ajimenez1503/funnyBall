using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuLevelLock : MonoBehaviour {

	enum TypeLock { LOCK=0, UNLOCK=1}; //0= lock and 1=unlock
	private int nLevel;//number of level
	public List<GameObject> levelCollider=new List<GameObject>();
	public List<GUITexture> levelLocked = new List<GUITexture> ();
	public List<GUITexture> levelUnlocked=new List<GUITexture>();


	private void initializePlayerPrefs(){
		//star in scene1 because scene0 will be unlock always
		for (int i = 1; i < nLevel; i++){
			//create a PlayerPrefs of that particular level and set it's to 0
			if(!PlayerPrefs.HasKey("SavedLevel"+i.ToString())){//if no key of that name exists
				PlayerPrefs.SetInt("SavedLevel"+i.ToString(),(int)TypeLock.LOCK);
				//create a atribute which will be changed in playerPrefs 
			}
				
		}
	}

	//initialize the level unlock and lock
	private void initializeLockLevel(){
		if(levelCollider.Count != 0 && levelLocked.Count != 0 && levelUnlocked.Count != 0){//not empty
			for (int i = 0; i < nLevel; i++){
				if(i==0){//leve0 unlock by default
					levelUnlocked[i].enabled = true;
					levelLocked[i].enabled = false;
					levelCollider[i].SetActive(true);
				}
				else{
					levelUnlocked[i].enabled = false;
					levelLocked[i].enabled = true;
					levelCollider[i].SetActive(false);
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
		for (int i = 1; i < nLevel; i++){
			//check the value of PlayerPrefs
			if(PlayerPrefs.HasKey("SavedLevel"+i.ToString())){
				if((int)TypeLock.UNLOCK==PlayerPrefs.GetInt("SavedLevel"+i.ToString())){//1==unlock
					levelUnlocked[i].enabled = true;
					levelLocked[i].enabled = false;
					levelCollider[i].SetActive(true);
				}
			}
			
		}

		//check the click of mouse on a level
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition); //typical mouse click input
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)){
				for (int i = 0; i < nLevel; i++){
					if(hit.collider.name == "Level"+i.ToString()+"Collider"){ //this is all of our code for triggering loading levels when a collider is clicked on
						Application.LoadLevel("Scene"+i.ToString());
					}
				}
			}
		}	
	}

	//add button 
	void OnGUI() {
		GUIStyle myButtonStyle = new GUIStyle(GUI.skin.button);
		myButtonStyle.fontSize = 30;
		//restart levels
<<<<<<< HEAD
		if (GUI.Button (new Rect ((Screen.width*1/4) - 55, Screen.height*3/4, 110, 60), /*buttonTextureRestart*/"Reset",myButtonStyle)) {
=======
		if (GUI.Button (new Rect ((Screen.width*1/4) - 55, Screen.height*3/4, 110, 60), /*buttonTextureRestart*/"Restart",myButtonStyle)) {
>>>>>>> 8172abea3ed608dd274286889318746fee256e15
			PlayerPrefs.DeleteAll();//delete PlayerPrefs and update the scene
			Application.LoadLevel("MainMenu");
		}

		if (GUI.Button (new Rect ((Screen.width*2/4) - 55, Screen.height*3/4, 110, 60), /*buttonTextureContinue*/"Credits",myButtonStyle)) {
			//go to credits
			Application.LoadLevel("Credits");
		}
		if (GUI.Button (new Rect ((Screen.width*3/4) - 55, Screen.height*3/4, 110, 60), /*buttonTextureContinue*/"Exit",myButtonStyle)) {
			//exit game
			Application.Quit();
		}
			
	}
}
