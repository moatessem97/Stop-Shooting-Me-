using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBoxScript : MonoBehaviour
{

    public Animator ballBox;

    bool leftButtonPushed;
    bool rightButtonPushed;
    bool openAlready;

	// Use this for initialization
	void Start ()
    {
        leftButtonPushed = false;
        rightButtonPushed = false;
        openAlready = false;
	}

    public void UpdateButtonActivity (string buttonChange)
    {
        if (buttonChange == "LeftPushed")
        {
            leftButtonPushed = true;
        }
        else if (buttonChange == "RightPushed")
        {
            rightButtonPushed = true;
        }
        else if (buttonChange == "LeftEmpty")
        {
            leftButtonPushed = false;
        }
        else if (buttonChange == "RightEmpty")
        {
            rightButtonPushed = false;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(openAlready == false)
        {
            if(leftButtonPushed == true && rightButtonPushed == true)
            {
                ballBox.SetBool("Puzzle Solved", true);
                openAlready = true;
            }
        }
	}
}
