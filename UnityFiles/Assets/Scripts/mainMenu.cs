using UnityEngine;
using System.Collections;

public class mainMenu : MonoBehaviour {

	public GUIStyle skin;
	public string credit = "Original Concept by: \n Nikko Williard and Andrew Mandula \n Backend provided by: \n Twine2Unity \n Scipt written by: \n Andrew Mandula and Nathaniel Case \n Development by: \n Nikko Williard, Andrew Mandula, Alex Mack \n Font Asset by G3Typefaces at dafont.com \n Music: \n Jason Weinberger Rendition of Mahler's Symphony No.5 I. Trauermarsh \n Remy Atwork by: \n Jennifer Kotler \n Special Thanks to Remy Decausemaker";

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

			GUI.Box(new Rect(Screen.width - (Screen.width-20), (Screen.height/3)-5, Screen.width - 10, Screen.height/4), "*Any legal advice is only relevant to fictional video game realities",skin);


			if(GUI.Button(new Rect(Screen.width - (Screen.width-20), 2*(Screen.height/4)-5, Screen.width - 10, Screen.height/4), "Play",skin))
			{
				if (Application.CanStreamedLevelBeLoaded ("GameGameGame")) 
				{
       				Application.LoadLevel ("GameGameGame");
    			}
			}

			if(GUI.Button(new Rect(Screen.width - (Screen.width-20), 3*(Screen.height/4)-5, Screen.width - 10, Screen.height/4), "Credits",skin))
			{
				ShowCredits = true;
			}

			GUI.Box(new Rect(Screen.width - (Screen.width-20), Screen.height - (Screen.height + 50), Screen.width, Screen.height/4), "*",skin);
		}
		else if(ShowCredits == true)
		{
			GUI.Box(new Rect(Screen.width- (Screen.width-20), Screen.height/20, Screen.width- 100, Screen.height-10),credit, skin);
			if(GUI.Button(new Rect(Screen.width- (Screen.width-20), Screen.height - (Screen.height-100), Screen.width-10, Screen.height-10),"Back",skin));
			{
				ShowCredits = false;
			}
		}
		
	}
}
