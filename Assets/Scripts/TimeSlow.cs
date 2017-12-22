using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSlow : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Fire2")) {
			Time.timeScale = 0.05f;
			Time.fixedDeltaTime = 0.05f * 0.02f;
		} else {
			Time.timeScale = 1;	
			Time.fixedDeltaTime = 0.02f;
		}

	}
}
