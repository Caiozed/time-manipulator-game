using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCountTrigger : MonoBehaviour {
	public EnemyController[] enemies;
	public GameObject objectToDeactivate;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		foreach (var enemy in enemies) {
			if (!enemy.isEnemyDead ()) {
				return;
			}
			objectToDeactivate.SetActive (false);
		}
	}
}
