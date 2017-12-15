using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour {

	public int speed = 5;
	public int jumpSesibility,jumpHeight = 5; 
	float height;
	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		float x = Input.GetAxis ("Horizontal") * speed  * Time.deltaTime * 60;
		float y = Input.GetAxis ("Vertical") * speed * Time.deltaTime * 60;
		bool isGrounded = Physics.Raycast (transform.position, -Vector3.up, 1);
		if (Input.GetButton ("Jump") && height < jumpHeight) {
			height += jumpSesibility * Time.fixedDeltaTime;
			rb.velocity = new Vector3 (rb.velocity.x, height, rb.velocity.z);
		} else {
			height = jumpHeight;
			if (isGrounded){
				height = 0;
			}
		}
		rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y , x);
	}
}
