using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitController : MonoBehaviour {
	public float timeToStart;

	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		Invoke ("StartTimer", timeToStart);
	}

	// Update is called once per frame
	void Update () {
	}

	void StartTimer(){
		anim.SetTrigger ("play");
	}

}
