using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeRewind : MonoBehaviour {
	List<TimeData> timeData = new List<TimeData>();
	GameObject player; 
	TimeRewindManager timeManager;
	Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		timeManager = player.GetComponent<TimeRewindManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate () {
		if (timeManager.isRewinding) {
			Rewind ();
		} else {
			if (timeData.Count < 40 * timeManager.timeRewindLength) {
				timeData.Insert (0, new TimeData (transform.position, transform.rotation, rb.velocity, rb.angularVelocity));
			} else {
				timeData.RemoveAt (timeData.Count -1);
			}
		}
	}

	void Rewind ()	{
		if (timeData.Count > 0) {
			transform.position = timeData[0].position;
			transform.rotation = timeData[0].rotation;
			rb.velocity = timeData[0].velocity;
			rb.angularVelocity = timeData[0].angularVelocity;
			timeData.RemoveAt (0);
		}
	}
}


public struct TimeData
{
	public Vector3 position;
	public Vector3 velocity;
	public Quaternion rotation;
	public Vector3 angularVelocity;


	public TimeData (Vector3 _position, Quaternion _rotation, Vector3 _velocity, Vector3 _angularVelocity) {
		position = _position;
		rotation = _rotation;
		velocity = _velocity;
		angularVelocity = _angularVelocity;
	}
}