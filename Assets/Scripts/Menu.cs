using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	
	private int count = 0;
	public GameObject menu;
	public GameObject options;

	public ScreenFader fade;

	public void PressButton(){
		count++;

		if (count % 2 == 1){
			menu.SetActive (true);
		}
		else{
			menu.SetActive (false);
		}
	}

	public void Back(){
		options.SetActive (false);
	}

	public void Options(){
		options.SetActive (true);
	}

	public void Quit(){
		menu.SetActive (false);
		fade.Fader(1f, 1f, true, "MainMenu");
	}
}
