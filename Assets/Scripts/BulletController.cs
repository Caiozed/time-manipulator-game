using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
	public int speed = 3;
	public GameObject hitEffect;
	public GameObject hitEffectEnemy;
	Rigidbody rb;
	MeshRenderer meshRenderer;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		meshRenderer = GetComponentInChildren<MeshRenderer> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rb.velocity = transform.forward * speed * Time.fixedDeltaTime * 60;
	}

	IEnumerator OnCollisionEnter(Collision other){
		meshRenderer.enabled = false;
		speed = 0;
		if (other.transform.CompareTag ("Enemy")) {
			other.gameObject.GetComponent<EnemyController> ().Die ();
			Instantiate (hitEffectEnemy, transform.position, transform.rotation);
		}else{
			Instantiate (hitEffect, transform.position, transform.rotation);
		};
		gameObject.GetComponent<Collider> ().enabled = false;
		yield return new WaitForSeconds (2);
		Destroy (gameObject);
	}
}
