using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCountTrigger : MonoBehaviour {
	public EnemyController[] enemies;
	public GameObject objectToInteract;
	public bool activate;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		int count = 0;
		foreach (var enemy in enemies) {
			if (enemy.isEnemyDead ()) {
				count++;
			}

			if (count == enemies.Length) {
				objectToInteract.SetActive (activate);
				Destroy (gameObject);
			}
		}
	}
}
