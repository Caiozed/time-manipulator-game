using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : MonoBehaviour {
	Rigidbody rb;
	Collider collider;
	public GameObject destroyEffect;
	public float throwRange = 5;
	// Use this for initialization
	void Start () {
		collider = GetComponent<Collider> ();
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.root.tag == "Player") {
			rb.isKinematic = true;
			rb.interpolation = RigidbodyInterpolation.None;
			if (Input.GetButtonUp ("ThrowWeapon")) {
				DropObject ();
			}
		}
	}

	public void DropObject (){
		Ray ray = Camera.main.ViewportPointToRay (new Vector2 (0.5f, 0.5f));
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) {
			transform.LookAt (hit.point);
		};
		rb.interpolation = RigidbodyInterpolation.Interpolate;
		collider.enabled = true;
		rb.isKinematic = false;
		transform.SetParent (null);
		rb.velocity = transform.TransformVector(new Vector3(0, Random.Range(5,7), throwRange));
		rb.angularVelocity = new Vector3 (Random.Range(-5,5), Random.Range(2,5), Random.Range(-5,5));
	}

	void OnCollisionEnter(Collision other){
		if (other.transform.tag =="Enemy") {
			if (rb.velocity.z > 0) {
				other.transform.GetComponent<EnemyController> ().Stagger ();
				Instantiate (destroyEffect, transform.position, transform.rotation);
				Destroy (gameObject);
			}
		}
	}
}

