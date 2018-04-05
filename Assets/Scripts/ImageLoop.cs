using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImageLoop : MonoBehaviour {

	public Sprite [] frames;
	public int framesPerSecond = 10;
	Image rend;
	int index;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Image> ();
	}

	void Update() {
		index = Mathf.RoundToInt ((Time.time * framesPerSecond) % frames.Length);
		index = Mathf.Clamp(index, 0, frames.Length - 1);
		rend.sprite = frames[index];
	}
}