using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuSelect : MonoBehaviour {

	private Text buttonText;
	public AudioSource click;
	public ScreenFader fade;

	void Start(){
		fade.Fader(0f, 1f, false, "");
	}


	public void Click(){
		click.Play ();
	}

	public void LoadLevelNew(){
		fade.Fader(1f, 1f, true, "NameEnter");
	}

	public void LoadSaveLevel(){
		fade.Fader(1f, 1f, true, "Credits");

	}

	public void LoadOption(){
		fade.Fader(1f, 1f, true, "Options");
	}

	public void QuitGame(){
		//Quit the game
		Application.Quit ();
	}

	public void Back(){
		fade.Fader(1f, 1f, true, "MainMenu");
	}

	public void ButtonHover(Text buttonText){
		//Set the button colour to yellow on hover
		buttonText.color = Color.yellow;
	}

	public void ButtonHoverOff(Text buttonText){
		//Set the text color back to white when the mouse goes off it
		buttonText.color = Color.white;
	}
}
