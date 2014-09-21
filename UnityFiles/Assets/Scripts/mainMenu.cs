using UnityEngine;
using System.Collections;

public class mainMenu : MonoBehaviour {

	public GUIStyle skin;
	public string credit = "Original Concept by: \n Nikko Williard and Andrew Mandula \n XML Backend provided by: \n Ed Mead \n Scipt written by: \n Andrew Mandula and Nathaniel Case \n Development by: \n Nikko Williard and Andrew Mandula \n Font Asset by G3Typefaces at dafont.com \n Music: \n Jason Weinberger Rendition of Mahler's Symphony No.5 I. Trauermarsh \n Remy Atwork by: \n Jennifer Kotler \n Special Thanks to Remy Decausemaker";
 
	bool ShowCredits;	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		
		if(ShowCredits == false)
		{
			GUI.Box(new Rect(Screen.width - (Screen.width-20), (Screen.height/4)-5, Screen.width - 10, Screen.height/4), "Remy the Flossopher VS Net Neutrality",skin);

			if(GUI.Button(new Rect(Screen.width - (Screen.width-20), 2*(Screen.height/4)-5, Screen.width - 10, Screen.height/4), "Play",skin))
			{
				Application.LoadLevel("GameGameGame");
			}

			if(GUI.Button(new Rect(Screen.width - (Screen.width-20), 3*(Screen.height/4)-5, Screen.width - 10, Screen.height/4), "Credits",skin))
			{
				ShowCredits = true;
			}

			GUI.Box(new Rect(Screen.width - (Screen.width-20), Screen.height - (Screen.height + 50), Screen.width, Screen.height/4), "*Any legal advice is only relevant to fictional video game realities",skin);
		}
		else if(ShowCredits == true)
		{
			GUI.Box(new Rect(Screen.width- (Screen.width-20), Screen.height/20, Screen.width- 10, Screen.height-10),credit, skin);
		}
		
	}
}
