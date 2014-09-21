using UnityEngine;
using System.Collections;

public class displayText : MonoBehaviour {

	public string textShownOnScreen;
	public string fullText = "The text you want shown on screen with typewriter effect.";
	public float wordsPerSecond = 2; // speed of typewriter
	private float timeElapsed = 0;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timeElapsed += Time.deltaTime;
		textShownOnScreen = GetWords(fullText, timeElapsed * wordsPerSecond);
	}

	void OnGUI() {
		GUI.Label(new Rect(5, 440, Screen.width - 10, Screen.height/4), "");
	}
	
	private string GetWords(string text, int wordCount)
	{
		int words = wordCount;
		
		// loop through each character in text
		for (int i = 0; i < text.Length; i++)
		{
			if (text[i] == ' ')
			{
				words--;
			}
			
			if (words <= 0)
			{
				return text.Substring(0, i);
			}
		}
		
		return text;
	}
}