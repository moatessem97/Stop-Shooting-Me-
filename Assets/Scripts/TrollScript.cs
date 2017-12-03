using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollScript : MonoBehaviour {

    public Renderer lol;
    float offset;

    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        offset = (0.2f * (Time.deltaTime)) + offset;
        Vector2 offffset = new Vector2(0, offset);
        lol.material.mainTextureOffset = offffset;
    }
}
