using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSlow : MonoBehaviour {
	public float powerDuration = 5;
	public float depleteRate, fillRate = 1;
	PlayerController playerController;
	float powerLevel;
	public RectTransform slowSlider;
	// Use this for initialization
	void Start () {
		powerLevel = powerDuration;
		playerController = GetComponent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Fire2")) {
			if(powerLevel > 0){
				StartSlow ();
				powerLevel -= Time.fixedUnscaledDeltaTime * depleteRate;
			}else{
				StopSlow ();
			}
		} else {
			if (!playerController.isDead) {
				StopSlow ();
				powerLevel += Time.fixedUnscaledDeltaTime * fillRate;
			}
		}
		powerLevel = Mathf.Clamp (powerLevel, 0, 5);
		slowSlider.localScale = new Vector3((powerLevel/powerDuration), 1, 1);
	}

	void StartSlow (){
		Time.timeScale = 0.05f;
		Time.fixedDeltaTime = 0.05f * 0.02f;
	}

	void StopSlow(){
		Time.timeScale = 1;	
		Time.fixedDeltaTime = 0.02f;
	}
}
