using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ScreenFader : MonoBehaviour {

	public GameObject fadeAlpha;

	public void Fader(float aValue, float aTime, bool endScene, string newLevel)
	{
		fadeAlpha.SetActive(true);
		StartCoroutine(FadeTo(aValue, aTime, endScene, newLevel));
	}

	IEnumerator FadeTo(float aValue, float aTime, bool endScene, string newLevel)
	{
		float alpha = fadeAlpha.transform.GetComponent<Image>().color.a;
		for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
		{
			Color newColor = new Color(0, 0, 0, Mathf.Lerp(alpha,aValue,t));
			fadeAlpha.GetComponent<Image>().color = newColor;
			yield return null;
		}
		if (!endScene)
			fadeAlpha.SetActive(false);

		if (endScene)
			Application.LoadLevel (newLevel);
	}
}
