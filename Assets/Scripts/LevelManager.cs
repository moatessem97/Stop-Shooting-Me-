using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	
	
	public void LoadLevel(string name){
		Time.timeScale = 1;

		Application.LoadLevel (name);
	}

	public void RestartLevel (string name){
		Time.timeScale = 1;
		Application.LoadLevel(Application.loadedLevel);


	}
	
	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}
	
	
	
	

}



