using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAnimation : MonoBehaviour {

	public string interactatedObjectTag, objectToTrigger, animationToTrigger;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.transform.CompareTag (interactatedObjectTag)) {
			GameObject clone = GameObject.FindGameObjectWithTag(objectToTrigger);
			clone.GetComponent<Animator> ().SetTrigger (animationToTrigger);
		}
	}
}
