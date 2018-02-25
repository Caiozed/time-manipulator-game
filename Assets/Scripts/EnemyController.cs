using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {
	public Vector3 offset;
	Transform chest;
	NavMeshAgent agent;
	GameObject player;
	float speed;
	Collider[] colliders;
	Rigidbody[] rbs;
	Rigidbody rb;
	CapsuleCollider collider;
	GunController gun;
	bool isDead = false;
	Animator anim;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		agent = GetComponent<NavMeshAgent> ();
		gun = GetComponentInChildren<GunController> ();
		anim = GetComponent<Animator> ();
		speed = agent.speed;
		collider = GetComponent<CapsuleCollider> ();
		colliders = GetComponentsInChildren<Collider> ();
		rb = GetComponent<Rigidbody> ();
		rbs = GetComponentsInChildren<Rigidbody> ();
		chest = anim.GetBoneTransform (HumanBodyBones.Spine);
		foreach (var item in colliders) {
			item.enabled = false;
		}
		foreach (var item in rbs) {
			item.isKinematic = true;
		}
		collider.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isDead) {
			RaycastHit hit;
			Vector3 position = new Vector3 (transform.position.x, transform.position.y + 1, transform.position.z);
			Debug.DrawLine (position,  player.transform.position);
			if (Physics.Raycast (position, player.transform.position - position, out hit)) {
				if (hit.transform.root.CompareTag ("Player")) {
					agent.speed = 0;
					//gun.ShootPlayer ();
					transform.LookAt (new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
					anim.SetBool("Shoot", true);
				} else {
					anim.SetBool("Shoot", false);
					agent.speed = speed;
				}
			} 
			agent.SetDestination (player.transform.position);
		}
	}

	void LateUpdate(){
		if (!isDead) {
			chest.LookAt (player.transform.position + transform.TransformVector (offset));
		}
	}

	/*void OnAnimatorIK(){
		if (anim) {
			anim.SetLookAtWeight (1);
			anim.SetLookAtPosition ( player.transform.position);
			anim.SetIKPositionWeight (AvatarIKGoal.RightHand, 1);
			anim.SetIKPositionWeight (AvatarIKGoal.LeftHand, 1);
			//anim.SetIKRotationWeight (AvatarIKGoal.RightHand, 1);
			//anim.SetIKRotation (AvatarIKGoal.RightHand, );
			anim.SetIKPosition (AvatarIKGoal.LeftHand, player.transform.position);
			anim.SetIKPosition (AvatarIKGoal.RightHand, player.transform.position);
		}
	}*/

	public void Die(){
		isDead = true;
		agent.enabled = false;
		GetComponent<Animator> ().enabled = false;
		foreach (var item in colliders) {
			item.enabled = true;
		}
		foreach (var item in rbs) {
			item.isKinematic = false;
		}
		gun.DropWeapon ();
		rb.isKinematic = true;
		collider.enabled = false;
	}

	public void ShootPlayer(){
		anim.speed = Random.Range (1f, 2f);
		gun.ShootPlayer ();
	}

	public void Stagger(){
		anim.SetTrigger ("Stagger");
	}

	public bool isEnemyDead (){
		return isDead;
	}
}
