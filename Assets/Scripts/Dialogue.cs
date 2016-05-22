using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour {

	public Text dialogue;
	public GameObject textPanel;
	public string[] chats; 
	private int chatCount = 0;
	private string genString;
	private static string name;

	public bool isCutscene;
	private float startTime;
	public float speed = 1.0F;
	public Transform char1;
	public Transform pos1;
	public Transform char2;
	public Transform pos2;

	int letterCount = 1;
	public ScreenFader fade;

	public bool midTalk;
	public GameObject plate;
	public GameObject picture;
	private bool end = false;

	void Start(){
		dialogue.text = "";
		StartCoroutine (TypeWriter (chats [chatCount].Length));
		name = PlayerSettings.name;
		startTime = Time.time;

	}

	string Replace(string full){
		if(full.Contains("<name>")){
			genString = "<name>";
			return full.Replace(genString, name);
		}
		return full;
	}

	void Update(){
		if (isCutscene && chatCount == 0) {
			StartCoroutine (Move(char1, char1, pos1));
		}
		if (isCutscene && chatCount == 1) {
			StartCoroutine (Move(char2, char2, pos2));
		}
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			if (!isCutscene) {
				plate.SetActive (true);
				picture.SetActive (true);
			}
			if (end) {
				fade.Fader(1f, 1f, true, "MainMenu");
			}
			if (chatCount >= chats.Length - 1) {
				if (isCutscene) {
					fade.Fader (1f, 1f, true, "Level1");
				} else {
					textPanel.SetActive(false);
				}
			} else {
				chatCount++;
				letterCount = 1;
				StartCoroutine (TypeWriter (chats [chatCount].Length));
			}
		}
	}

	private void GetWords()
	{
		dialogue.text = Replace (chats [chatCount]).Substring (0, letterCount);
		letterCount++;
	}

	public void OnClickPlate(){
		dialogue.text = "";
		chats = new string[1];
		chats [0] = "Great job! You found a clue!";

		chatCount = 0;
		letterCount = 1;
		StartCoroutine(TypeWriter(chats[chatCount].Length));
		end = true;

	}   

	public void OnClickPaint(){
		dialogue.text = "";
		chats = new string[3];
		chats [0] = "Nice try!";
		chats [1] = "But sadly this suspicious picture isn't suspicious enough...";
		chats [2] = "Keep looking!";

		chatCount = 0;
		letterCount = 1;
		StartCoroutine(TypeWriter(chats[chatCount].Length));
	}   

	public void OnPlateHover(){
		plate.GetComponent<Image>().color = new Color(0f, 0f, 0f, 1f);
	}

	public void OnPlateLeave(){
		plate.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0f);
	}

	public void OnPaintHover(){
		picture.GetComponent<Image>().color = new Color(0f, 0f, 0f, 1f);
	}

	public void OnPaintLeave(){
		picture.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0f);
	}

	IEnumerator Move(Transform character, Transform inital, Transform final) {
		for (float i = 0; i < speed; i += Time.deltaTime) {
			character.position = Vector2.Lerp (inital.position, final.position, i/speed);
			yield return new WaitForSeconds(.1f);
		}
	}

	IEnumerator TypeWriter(int number)
	{
		int i = 0;
		while(i < number)
		{
			textPanel.SetActive(true);
			GetWords();
			i++;
			yield return 0;
		}
	}

}
