using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//from http://wiki.unity3d.com/index.php/AutoType
public class AutoType : MonoBehaviour {
	
	public GUIStyle skin;
	public float letterPause = 0.0001f; //time-wait before next letter is printed : type float
	//Sprite decleration
	public SpriteRenderer mouse;
	public SpriteRenderer remy;
	public SpriteRenderer comcast;
	public SpriteRenderer judge;
	public SpriteRenderer explosion;
	//Audio decleration
	public AudioSource remyAudio = new AudioSource();
	public AudioSource judgeAudio = new AudioSource();
	public AudioSource comcastAudio = new AudioSource();
	public AudioSource musicAudio = new AudioSource();
	string message = "";
	string speaker = "";
	public bool canClick = false;
	public bool choice = false;
	Vector3 mousePos;
	public TwineImporter1 Twine;
	public List<string> choicesList;
	public List<string> choicesLinksList;

	// Use this for initialization
	void Start () {
		Twine = new TwineImporter1();
//		GUI.skin = GameGui;
		mousePos = new Vector3 (8, -4, -9);
		mouse.transform.position= mousePos;
		mouse.enabled = false;
		remy.enabled = false;
		comcast.enabled = false;
		judge.enabled = false;
		explosion.enabled = false;

//		remyClips[0] = AudioClip.Create("R_eh-eh.mp3", 44100, 1, 44100, false, true);
//		remyClips[1] = AudioClip.Create("R_Hmmmm.mp3", 44100, 1, 44100, false, true);
//		remyClips[2] = AudioClip.Create("R_Mhma.mp3", 44100, 1, 44100, false, true);
		//remyClips[3] = "R_mmhm.mp3";
		//remyClips[4] = "R_MMM.mp3";
		//remyClips[5] = "R_pssh.mp3";
		// string toDisplay = "Whatever data is being sent, be it cat pictures, live video, " +
		// "or life-saving tools about water filtration, all this data is subjected" +
		// 	"to Internet Service Providers whims without Net Neutrality. Net Neutrality" +
		// 		"keeps Internet Service Provider fair and balanced about their data transfer. " +
		// 		"Without Net Neutrality, cat pictures online could be eradicated. ";

		StartCoroutine (TypeText ());
	}
	
	
	// Update is called once per frame
	void Update (){
		if(Input.GetMouseButtonDown(0) && canClick == true){
			remy.enabled = false;
			comcast.enabled = false;
			judge.enabled = false;
			explosion.enabled = false;
			StopCoroutine(createMessage());
			StartCoroutine (TypeText());
		}

	}
	
	//Draws the text box
	void OnGUI() {
//		FontStyle bold;
		GUI.skin.box.wordWrap = true;
		if(choice == false)
		{
			GUI.Box(new Rect(Screen.width - (Screen.width-5), 3*(Screen.height/4)-5, Screen.width - 10, Screen.height/4), message,skin);
			GUI.Box(new Rect(Screen.width - (Screen.width-5), 3*(Screen.height/4)-6*(Screen.height/8), Screen.width/5, Screen.height/10), speaker,skin);
			//Twine.TwineData.NextNode(Twine.TwineData.Current.Link);
		}
		else if (choice == true)
		{
			if(GUI.Button(new Rect(Screen.width - (Screen.width -5), 3*(Screen.height/4), Screen.width - 10, Screen.height/4/4),choicesList[0],skin))
			{
				Twine.TwineData.NextNode(choicesLinksList[0]);
				Twine.TwineData.NextNode(Twine.TwineData.Current.LinkData);
				//StartCoroutine(createMessage());
				message = Twine.TwineData.Current.Content;
				speaker = Twine.TwineData.Current.Speaker;
				//Checks for number of charecters to display
				/*if(speaker == "Remy/Comcast")
				{
					remy.enabled = true;
					comcast.enabled = true;
				}
				else
				{
					remy.enabled = true;
					comcast.enabled = true;
					judge.enabled = true;
				}*/

				choice = false;
			}

			if(GUI.Button(new Rect(Screen.width - (Screen.width -5), 3*(Screen.height/4)+Screen.height/4/4, Screen.width - 10, Screen.height/4/4),choicesList[1],skin))
			{
				Twine.TwineData.NextNode(choicesLinksList[1]);
				Twine.TwineData.NextNode(Twine.TwineData.Current.LinkData);
				//StartCoroutine(createMessage());
				message = Twine.TwineData.Current.Content;
				speaker = Twine.TwineData.Current.Speaker;
				choice = false;
				explosion.enabled = true;
				Twine.TwineData.NextNode(Twine.TwineData.Current.LinkData);
			}

			if(GUI.Button(new Rect(Screen.width - (Screen.width -5), 3*(Screen.height/4)+2*(Screen.height/4/4), Screen.width - 10, Screen.height/4/4),choicesList[2],skin))
			{
				Twine.TwineData.NextNode(choicesLinksList[2]);
				Twine.TwineData.NextNode(Twine.TwineData.Current.LinkData);
				//StartCoroutine(createMessage());
				message = Twine.TwineData.Current.Content;
				speaker = Twine.TwineData.Current.Speaker;
				choice = false;
				explosion.enabled = true;
				Twine.TwineData.NextNode(Twine.TwineData.Current.LinkData);
			}

			if(GUI.Button(new Rect(Screen.width - (Screen.width -5), 3*(Screen.height/4)+3*(Screen.height/4/4), Screen.width - 10, Screen.height/4/4),choicesList[3],skin))
			{
				Twine.TwineData.NextNode(choicesLinksList[3]);
				Twine.TwineData.NextNode(Twine.TwineData.Current.LinkData);
				//StartCoroutine(createMessage());
				message = Twine.TwineData.Current.Content;
				speaker = Twine.TwineData.Current.Speaker;
				choice = false;
				explosion.enabled = true;
				Twine.TwineData.NextNode(Twine.TwineData.Current.LinkData);
			}	
		}
		
	}

	IEnumerator TypeText () {
		canClick = false;
		message = "";
		speaker = Twine.TwineData.Current.Speaker;
		TwineNode1 tempNode;
		if (speaker == "\r\nRemy")
		{
			remy.enabled = true;
			remyAudio.Play();
		}
		if (speaker == "\r\nComcast") 
		{
			comcast.enabled = true;
			comcastAudio.Play();
		}
		if (speaker == "Judge")
		{
			judge.enabled = true;
			judgeAudio.Play();
		}
		else if(speaker == "\r\nRemy/Comcast")
		{
			remy.enabled = true;
			comcast.enabled = true;
			comcastAudio.Play();
		}
		if(Twine.TwineData.Current.LinkTitle[0] == "Test")
		{
			choice = false;
			speaker = Twine.TwineData.Current.Speaker;
			foreach (char letter in Twine.TwineData.Current.Content.ToCharArray()) 
			{
				message += letter;
				yield return 0;
				yield return new WaitForSeconds (letterPause);
			}
            Twine.TwineData.NextNode(Twine.TwineData.Current.LinkData);
		}
		else
		{	
			choice = true;
			tempNode = Twine.TwineData.Current;
			foreach (string currentChoice in Twine.TwineData.Current.Link)
			{
				Twine.TwineData.NextNode(currentChoice);
				choicesLinksList.Add(currentChoice);
				choicesList.Add (Twine.TwineData.Current.Content);
			}
			Twine.TwineData.Current = tempNode;
		}
			
		
		canClick = true;
		mouse.enabled = true;
	}

	IEnumerator createMessage()
	{
		foreach (char letter in Twine.TwineData.Current.Content) 
		{
			message += letter;
			yield return 0;
			yield return new WaitForSeconds (letterPause);
		}
	}
}
