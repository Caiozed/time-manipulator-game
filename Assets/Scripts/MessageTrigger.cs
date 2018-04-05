using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageTrigger : MonoBehaviour {
	public string message;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.transform.root.CompareTag ("Player")) {
			PlayerController player = other.transform.root.GetComponent<PlayerController> ();
			player.messageText.text = message;
			player.canvasAnim.SetTrigger ("message");
			Destroy (gameObject);
		}
	}
}
