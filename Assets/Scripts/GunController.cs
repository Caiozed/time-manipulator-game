using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {
	public int bullets = 7;
	public GameObject bullet;
	public GameObject bulletCase;
	public Transform barrel;
	public Transform casePosition;
	public ParticleSystem bulletEffect;
	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		Shoot ();
	}

	void Shoot(){
		if (Input.GetButtonUp ("Fire1")) {
			if (bullets > 0) {
				Instantiate (bullet, barrel.position, barrel.rotation);
				GameObject bCase = Instantiate (bulletCase, casePosition.position, casePosition.rotation);
				bulletEffect.Play ();
				bCase.GetComponent<Rigidbody> ().velocity = new Vector3 (Random.Range(1.5f, 3), Random.Range(1.5f, 3), 0);
				bullets --;
			}
			anim.SetTrigger ("Shoot");
		}
	}
}
