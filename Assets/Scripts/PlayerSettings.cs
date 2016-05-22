using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PlayerSettings : MonoBehaviour {

	public Slider sliderSound;
	public static string name;
	private float VolumeSliderGet;
	public InputField mainInputField;
	public ScreenFader fade;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this);
		if (mainInputField != null)
			mainInputField.onEndEdit.AddListener(delegate{nameSubmit(mainInputField);});
	}

	public void nameSubmit(InputField input){
		name = input.text;
		fade.Fader(1f, 1f, true, "Cutscene");
	}

	public void ChangeVolume(){
		VolumeSliderGet = sliderSound.value;
		AudioListener.volume = VolumeSliderGet;
	}
}
