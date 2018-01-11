using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationTrigger : MonoBehaviour {
	public GameObject[] objectsToActivate;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.transform.root.CompareTag ("Player")) {
			foreach (var item in objectsToActivate) {
				item.SetActive (true);
			}
			Destroy (gameObject);
		}
	}
}
