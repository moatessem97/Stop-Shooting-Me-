using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.EventSystems; 
using System.Collections;

public class ButtonController : MonoBehaviour
{


	public void LoadScene(string SceneToLoad) 
	{
		Application.LoadLevel("IntroTutorial");
	}

	public void Quit()
	{
		Application.Quit (); 
	}




}
