﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour {
	public int timeToDestroy = 5;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, timeToDestroy);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
