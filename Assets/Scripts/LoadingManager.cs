using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour {
	AsyncOperation async;
	static int levelToLoad;
	public Text loadingText;
	// Use this for initialization
	void Start () {
		async = SceneManager.LoadSceneAsync (levelToLoad);
		async.allowSceneActivation = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (async.progress == 0.9f) {
			loadingText.text = "Click to continue!";
			if(Input.GetButtonDown("Fire1")){
				async.allowSceneActivation = true;
			}
		}
	}

	public static void LoadLevel(int level){
		levelToLoad = level;
		SceneManager.LoadScene (SceneManager.sceneCountInBuildSettings-1);
	}

	public static int CurrentLevel(){
		return SceneManager.GetActiveScene ().buildIndex;
	}
}
