using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {
	public int bullets = 7;
	public GameObject bullet;
	public Transform barrel;
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
				bullets --;
			}
			anim.SetTrigger ("Shoot");
		}
	}
}
