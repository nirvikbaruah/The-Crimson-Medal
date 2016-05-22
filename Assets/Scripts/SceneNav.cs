using UnityEngine;
using System.Collections;

public class SceneNav : MonoBehaviour {

	public GameObject[] scenes;
	public int count;
	private int SCENES_LEN;

	void Start(){
		SCENES_LEN = scenes.Length - 1;
		count = SCENES_LEN;
	}

	void Update () {
	
	}

	public void GoRight() {
		count++;
		showScenes ();
	}

	public void GoLeft() {
		count--;
		showScenes ();
	}

	void showScenes(){
		if (count > SCENES_LEN) {
			count = 0;
		}
		if (count < 0) {
			count = SCENES_LEN;
		}

		foreach (GameObject scene in scenes){
			scene.active = false;
		}
		scenes [count].active = true;
	}
}
