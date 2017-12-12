using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseControllerButton : MonoBehaviour {

    private LevelManager LMS;

    private void Awake()
    {
        LMS = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            LMS.RestartLevel(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            LMS.LoadLevel("Menu");
        }
    }
}
