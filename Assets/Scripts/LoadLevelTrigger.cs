using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelTrigger : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		Debug.Log("enter");
		if (other.transform.root.CompareTag ("Player")) {
			LoadingManager.LoadLevel (LoadingManager.CurrentLevel()+1);
		}
	}
}
