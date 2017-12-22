using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
	public int speed = 3;
	public GameObject hitEffect;
	Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rb.velocity = transform.forward * speed * Time.fixedDeltaTime * 60;
	}

	IEnumerator OnCollisionEnter(){
		Instantiate (hitEffect, transform.position, transform.rotation);
		yield return new WaitForSeconds (2);
		Destroy (gameObject);
	}
}
