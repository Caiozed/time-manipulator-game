using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeRewindManager : MonoBehaviour {
	public bool isRewinding;
	public float timeRewindLength = 5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Jump")) {
			isRewinding = true;
		} else {
			isRewinding = false;
		}
	}
}
