using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectAddForce : MonoBehaviour {
	public GameObject[] objectsToAddForce;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonUp ("Fire1")) {
			foreach (var item in objectsToAddForce) {
				Vector3 randomVector = new Vector3(Random.Range(-100, 100), Random.Range(-100, 100), Random.Range(-100, 100));
				item.GetComponent<Rigidbody>().AddForce(randomVector*20);
			}
		}
	}
}
