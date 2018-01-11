﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {
	public int bullets = 7;
	public float throwRange = 5;
	public GameObject bullet;
	public GameObject bulletCase;
	public Transform barrel;
	public Transform casePosition;
	ParticleSystem bulletEffect;
	Rigidbody rb;
	Collider collider;
	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		collider = GetComponent<Collider> ();
		rb = GetComponent<Rigidbody> ();
		bulletEffect = barrel.GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.parent) {
			collider.enabled = false;
			rb.isKinematic = true;
			if (transform.root.tag == "Player") {
				if (Input.GetButtonUp ("ThrowWeapon")) {
					DropWeapon ();
				}
				Shoot ();
			}
		} else {
			collider.enabled = true;
			rb.isKinematic = false;
		}


	}

	void Shoot(){
		if (Input.GetButtonUp ("Fire1")) {
			if (bullets > 0) {
				Ray ray = Camera.main.ViewportPointToRay (new Vector2 (0.5f, 0.5f));
				RaycastHit hit;
				GameObject bulletClone = Instantiate (bullet, barrel.position, barrel.rotation);
				GameObject bCase = Instantiate (bulletCase, casePosition.position, casePosition.rotation);
				bulletEffect.Play ();
				bCase.GetComponent<Rigidbody> ().velocity = new Vector3 (Random.Range(1.5f, 3), Random.Range(1.5f, 3), 0);
				bullets --;
				if (Physics.Raycast (ray, out hit)) {
					bulletClone.transform.LookAt (hit.point);
				};
			}
			anim.SetTrigger ("Shoot");
		}
	}

	public void ShootPlayer(/*Transform player*/){
			GameObject bulletClone = Instantiate (bullet, barrel.position, barrel.rotation);
			GameObject bCase = Instantiate (bulletCase, casePosition.position, casePosition.rotation);
			//bulletClone.transform.LookAt (player.position);
			bulletClone.transform.LookAt(Camera.main.transform.position);
			bulletEffect.Play ();
			bCase.GetComponent<Rigidbody> ().velocity = new Vector3 (Random.Range(1.5f, 3), Random.Range(1.5f, 3), 0);
			anim.SetTrigger ("Shoot");
	}

	public void DropWeapon(){
		collider.enabled = true;
		rb.isKinematic = false;
		transform.SetParent (null);
		rb.velocity = transform.forward *  throwRange;
		rb.angularVelocity = new Vector3 (Random.Range(-5,5), Random.Range(-5,5), Random.Range(-5,5));
	}
}
