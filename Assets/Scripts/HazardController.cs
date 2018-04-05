﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	void OnTriggerEnter(Collider other){
		if (other.transform.root.CompareTag ("Player")) {
			other.transform.root.GetComponent<PlayerController> ().Die ();
		}
	}
}
