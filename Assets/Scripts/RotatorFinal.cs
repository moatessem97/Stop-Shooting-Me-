﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorFinal : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0, 1, 0) * Time.deltaTime, 0.08f);

	}
}
