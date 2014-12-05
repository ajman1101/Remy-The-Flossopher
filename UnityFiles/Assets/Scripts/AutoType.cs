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
	//public List<Frame> list = new List<Frame> ();
	//public Game data = new Game();
	//int count = 0;
	string message = "";
	string speaker = "";
	public bool canClick = false;
	public bool choice = false;
	Vector3 mousePos;
	public TwineImporter1 Twine;
	public List<string> choicesList;

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

		// data = loadFrames("Assets/XML/dialogue.xml");
		// foreach(Frame f in data.getFrames){
		// 	list.Add(f);
		// }
		// Debug.Log(list.Count);

		StartCoroutine (TypeText ());
	}
	//though a function for the Game class
	//this is kept outside to be used in unity runtime
	Game loadFrames(string xmlFile){
		System.Xml.Serialization.XmlSerializer serializer = 
			new System.Xml.Serialization.XmlSerializer(typeof(Game));
		System.IO.TextReader reader = 
			new System.IO.StreamReader(xmlFile);
		Game ObjItems = (Game)serializer.Deserialize(reader);
		reader.Close();
		return ObjItems;
	}
	
	
	// Update is called once per frame
	void Update (){
		if(Input.GetMouseButtonDown(0) && canClick == true){
			remy.enabled = false;
			comcast.enabled = false;
			judge.enabled = false;
			explosion.enabled = false;
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
				//message = list[count+4].text;
				//speaker = list[count+4].speaker;
				//Checks for number of charecters to display
				if(speaker == "Remy/Comcast")
				{
					remy.enabled = true;
					comcast.enabled = true;
				}
				else
				{
					remy.enabled = true;
					comcast.enabled = true;
					judge.enabled = true;
				}

				choice = false;
				Twine.TwineData.NextNode(choicesList[0]);
			}

/*			if(GUI.Button(new Rect(Screen.width - (Screen.width -5), 3*(Screen.height/4)+Screen.height/4/4, Screen.width - 10, Screen.height/4/4),choicesList[1],skin))
			{
				//message = list[count+5].text;
				//speaker = list[count+5].speaker;
				choice = false;
				explosion.enabled = true;
			}

			if(GUI.Button(new Rect(Screen.width - (Screen.width -5), 3*(Screen.height/4)+2*(Screen.height/4/4), Screen.width - 10, Screen.height/4/4),choicesList[2],skin))
			{
				//message = list[count+6].text;
				//speaker = list[count+6].speaker;
				choice = false;
				explosion.enabled = true;
			}

			if(GUI.Button(new Rect(Screen.width - (Screen.width -5), 3*(Screen.height/4)+3*(Screen.height/4/4), Screen.width - 10, Screen.height/4/4),choicesList[3],skin))
			{
				//message = list[count+7].text;
				//speaker = list[count+7].speaker;
				choice = false;
				explosion.enabled = true;
			}*/	
		}
		
	}

	IEnumerator TypeText () {
		canClick = false;
		message = "";
		//Debug.Log(Twine.TwineData.Current.Link);
		//int speakerTo = Twine.data.Current.Content.IndexOf(":");
		//speaker = Twine.data.Current.Content;
		if (speaker == "Remy")
		{
			remy.enabled = true;
			remyAudio.Play();
		}
		if (speaker == "Comcast") 
		{
			comcast.enabled = true;
			comcastAudio.Play();
		}
		if (speaker == "Judge")
		{
			judge.enabled = true;
			judgeAudio.Play();
		}
		else if(speaker == "Remy/Comcast")
		{
			remy.enabled = true;
			comcast.enabled = true;
			comcastAudio.Play();
		}
		if(Twine.TwineData.Current.LinkTitle[0] == "Test")
		{
			choice = false;
			/*foreach (char letter in Twine.TwineData.current.Content.ToCharArray()) 
			{
				message += letter;
				yield return 0;
				yield return new WaitForSeconds (letterPause);
			}*/
			speaker = Twine.TwineData.Current.Speaker;
			message = Twine.TwineData.Current.Content;
			Debug.Log("Message: " + message + " Next Link: " + Twine.TwineData.Current.Link);
			Twine.TwineData.NextNode(Twine.TwineData.Current.Link);
			yield return 0;
			//Debug.Log (Twine.TwineData.Current.Link);
			//Twine.TwineData.NextNode(Twine.TwineData.Current.Link);
		}
		else
		{	
			choice = true;
			foreach (string currentChoice in Twine.TwineData.Current.LinkTitle)
			{
				choicesList.Add (currentChoice);
			}
		//	count+=4;
		}
			
		
		canClick = true;
		mouse.enabled = true;
	}
}
