using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour {
	public int speed = 5;
	public float sensitivityX, sensitivityY = 5;
	public int jumpSesibility,jumpHeight = 5; 
	float height, yaw, pitch;
	Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		Move ();
		Rotate ();
	}

	void Move(){
		float x = Input.GetAxis ("Horizontal") * speed  * Time.unscaledDeltaTime * 60;
		float z = Input.GetAxis ("Vertical") * speed  * Time.unscaledDeltaTime * 60;

		bool isGrounded = Physics.Raycast (transform.position, -Vector3.up, 1.5f);
		if (Input.GetButton ("Jump") && height < jumpHeight) {
			height += jumpSesibility * Time.unscaledDeltaTime;
			rb.velocity = new Vector3 (rb.velocity.x, height, rb.velocity.z);
		} else {
			height = jumpHeight;
			if (isGrounded){
				height = 0;
			}
		}
		rb.velocity = transform.TransformVector(new Vector3(x , rb.velocity.y, z));
	}

	void Rotate(){
		Transform cameraTransform = Camera.main.transform;
		pitch += Input.GetAxis("Mouse Y") * sensitivityX * Time.unscaledDeltaTime *60;
		yaw = Input.GetAxis("Mouse X") * sensitivityY * Time.unscaledDeltaTime *60 ;

		pitch = Mathf.Clamp (pitch, -90, 90);
		cameraTransform.eulerAngles = new Vector3(-pitch, transform.eulerAngles.y, 0.0f);;
		transform.Rotate(Vector3.up * yaw);
	}


}
