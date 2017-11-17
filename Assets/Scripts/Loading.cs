using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour {
	
	// Use this for initialization
	 void Start() {
		
		StartCoroutine ("Wait");
	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds (4);

		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
