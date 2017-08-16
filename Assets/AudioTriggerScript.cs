using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTriggerScript : MonoBehaviour {

    public AudioSource mySource;

    private bool StartAud;
	void Start () {
        StartAud = false;
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !StartAud)
        {
            StartAud = true;
            mySource.Play();
        }
    }
}
