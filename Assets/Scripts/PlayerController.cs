using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	public Text infoText;
	public Text messageText;
	public Animator canvasAnim;
	public GameObject gunPlace;

	public bool godMode;
	[HideInInspector]
	public bool isDead;

	Vector3 velocity;

	PlayerMovementController playerMovementController;
	TimeSlow timeSlow;
	TimeRewindManager timeRewind;

	// Use this for initialization
	void Start () {
		messageText.text = "GUN";
		Invoke("startAnimText", 1);
		playerMovementController = GetComponent<PlayerMovementController> ();
		timeSlow = GetComponent<TimeSlow> ();
		timeRewind = GetComponent<TimeRewindManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		InteractableRaycast ();
		if (isDead) {
			if (Input.GetButtonDown ("Fire1")) {
				LoadingManager.LoadLevel (LoadingManager.CurrentLevel ());
			}
		}
	}

	void startAnimText(){
		canvasAnim.SetTrigger ("message");
	}

	IEnumerator AdjustPosition(Transform other){
		bool adjustPosition = true;
		while (adjustPosition) {
			other.localPosition = Vector3.SmoothDamp(other.localPosition, Vector3.zero, ref velocity, 0.1f);
			other.localRotation = Quaternion.identity;
			if (other.localPosition == Vector3.zero || !other.transform.parent) {
				adjustPosition = false;
			}
			yield return new WaitForSeconds (Time.fixedDeltaTime);
		}
	}

	void InteractableRaycast(){
		Ray ray = Camera.main.ViewportPointToRay (new Vector2 (0.5f, 0.5f));
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 3)) {
			if (gunPlace.transform.childCount == 0 && hit.transform.CompareTag("Interactable")) {
				infoText.text = "Press 'E' to pick up";
				if (Input.GetButtonUp ("Interact")) {
					hit.transform.SetParent (gunPlace.transform);
					StartCoroutine(AdjustPosition (hit.transform));
				} 
			} else {
				infoText.text = "";
			}
		}
	}

	public void Die(){
		if (!godMode) {
			isDead = true;
			messageText.text = "DEAD";
			infoText.text = "Press any button to restart !";
			Time.timeScale = 0;
			playerMovementController.enabled = false;
			timeRewind.enabled = false;
			timeSlow.enabled = false;
			canvasAnim.SetBool ("isDead", isDead);
		}
	}

	void OnTriggerEnter (Collider other){
		if (other.transform.CompareTag ("Interactable") && gunPlace.transform.childCount == 0 ) {
			other.transform.SetParent (gunPlace.transform);
			StartCoroutine(AdjustPosition (other.transform));
		}
	}
}
