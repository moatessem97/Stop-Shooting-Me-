using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBoxDetection : MonoBehaviour
{
    public Animator secretdoors;
    public GameObject[] hallLights;
    string lightBoxStateOne;
    string lightBoxStateTwo;
    bool puzzleIncomplete;

	// Use this for initialization
	void Start ()
    {
        lightBoxStateOne = "Missing";
        lightBoxStateTwo = "Missing";
        puzzleIncomplete = true;
        hallLights = GameObject.FindGameObjectsWithTag("HallLight");
        for(int i = 0; i <= hallLights.Length-1; i++)
        {
            hallLights[i].GetComponent<Light>().enabled = false;
        }
	}

    public void UpdateBoxPlacementState(string identifier, string state)
    {
        if(identifier == "lbStorageOne")
        {
            lightBoxStateOne = state;
        }
        else if (identifier == "lbStorageTwo")
        {
            lightBoxStateTwo = state;
        }
    }

    void CompletePuzzle()
    {
        secretdoors.SetBool("LightBoxesPlaced", true);
        for (int i = 0; i <= hallLights.Length-1; i++)
        {
            hallLights[i].GetComponent<Light>().enabled = true;
        }
        puzzleIncomplete = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (puzzleIncomplete == true)
        {
            if (lightBoxStateOne == "Present" && lightBoxStateTwo == "Present")
            {
                CompletePuzzle();
            }
        }
	}
}
