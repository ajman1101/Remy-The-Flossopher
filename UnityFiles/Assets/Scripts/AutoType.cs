using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//from http://wiki.unity3d.com/index.php/AutoType
public class AutoType : MonoBehaviour {
	
	public GUIStyle skin;
	public float letterPause = 0.0001f;
	public SpriteRenderer mouse;
	public SpriteRenderer remy;
	public SpriteRenderer comcast;
	public SpriteRenderer judge;
	public SpriteRenderer explosion;
	public AudioClip sound;
	public List<Frame> list = new List<Frame> ();
	public Game data = new Game();
	int count = 0;
	string message = "";
	string speaker = "";
	public bool canClick = false;
	public bool choice = false;
	Vector3 mousePos;

	// Use this for initialization
	void Start () {
//		GUI.skin = GameGui;
		mousePos = new Vector3 (8, -4, -9);
		mouse.transform.position= mousePos;
		mouse.enabled = false;
		remy.enabled = false;
		comcast.enabled = false;
		judge.enabled = false;
		explosion.enabled = false;
		string toDisplay = "Whatever data is being sent, be it cat pictures, live video, " +
		"or life-saving tools about water filtration, all this data is subjected" +
			"to Internet Service Providers whims without Net Neutrality. Net Neutrality" +
				"keeps Internet Service Provider fair and balanced about their data transfer. " +
				"Without Net Neutrality, cat pictures online could be eradicated. ";
		data = loadFrames("Assets/XML/dialogue.xml");
		foreach(Frame f in data.getFrames){
			list.Add(f);
		}
		Debug.Log(list.Count);
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
		FontStyle bold;
		GUI.skin.box.wordWrap = true;
		if(choice == false)
		{
			GUI.Box(new Rect(Screen.width - (Screen.width-5), 3*(Screen.height/4)-5, Screen.width - 10, Screen.height/4), message,skin);
			GUI.Box(new Rect(Screen.width - (Screen.width-5), 3*(Screen.height/4)-6*(Screen.height/8), Screen.width/5, Screen.height/10), speaker,skin);
		}
		else if (choice == true)
		{
			if(GUI.Button(new Rect(Screen.width - (Screen.width -5), 3*(Screen.height/4), Screen.width - 10, Screen.height/4/4),list[count].choice,skin))
			{
				message = list[count+4].text;
				speaker = list[count+4].speaker;
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
				count+=8;
			}

			if(GUI.Button(new Rect(Screen.width - (Screen.width -5), 3*(Screen.height/4)+Screen.height/4/4, Screen.width - 10, Screen.height/4/4),list[count+1].choice,skin))
			{
				message = list[count+5].text;
				speaker = list[count+5].speaker;
				choice = false;
				explosion.enabled = true;
			}

			if(GUI.Button(new Rect(Screen.width - (Screen.width -5), 3*(Screen.height/4)+2*(Screen.height/4/4), Screen.width - 10, Screen.height/4/4),list[count+2].choice,skin))
			{
				message = list[count+6].text;
				speaker = list[count+6].speaker;
				choice = false;
				explosion.enabled = true;
			}

			if(GUI.Button(new Rect(Screen.width - (Screen.width -5), 3*(Screen.height/4)+3*(Screen.height/4/4), Screen.width - 10, Screen.height/4/4),list[count+3].choice,skin))
			{
				message = list[count+7].text;
				speaker = list[count+7].speaker;
				choice = false;
				explosion.enabled = true;
			}	
		}
		
	}

	IEnumerator TypeText () {
		canClick = false;
		message = "";
		speaker = list[count].speaker;
		if (speaker == "Remy")
		{
			remy.enabled = true;
		}
		if (speaker == "Comcast") 
		{
			comcast.enabled = true;
		}
		if (speaker == "Judge")
		{
			judge.enabled = true;
		}
		else if(speaker == "Remy/Comcast")
		{
			remy.enabled = true;
			comcast.enabled = true;
		}
		if(list[count].choice == null)
		{
			choice = false;
			foreach (char letter in list[count].text.ToCharArray()) 
			{
				message += letter;
				if (sound)
						audio.PlayOneShot (sound);
				//Debug.Log ("TypeText: Message - " + message);
				yield return 0;
				yield return new WaitForSeconds (letterPause);
			}
			count++;
		}
		else if(list[count].choice != null)
		{	
			choice = true;
		//	count+=4;
		}
			
		
		canClick = true;
		mouse.enabled = true;
	}
}
