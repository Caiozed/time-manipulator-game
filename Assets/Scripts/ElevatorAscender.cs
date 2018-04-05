using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorAscender : MonoBehaviour {
	bool move;
	public Transform elevatorStop;
	public float speed = 5, timeToStart=2;
	Vector3 startPos;
	float timer;
	// Use this for initialization
	void Start () {
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (timer);

		float step = speed * Time.deltaTime;
		if (move) {
			timer += Time.deltaTime;
			if (timer > timeToStart) {
				transform.position = Vector3.MoveTowards (transform.position, elevatorStop.position, step);
			}
		} else {
			transform.position = Vector3.MoveTowards (transform.position, startPos, step);
		}
	}


	void OnTriggerEnter (Collider other){
		if (other.transform.root.CompareTag ("Player")) {
			move = true;
		}
	}

	void OnTriggerExit (Collider other){
		if (other.transform.root.CompareTag ("Player")) {
			move = false;
			timer = 0;
		} 
	}
}
