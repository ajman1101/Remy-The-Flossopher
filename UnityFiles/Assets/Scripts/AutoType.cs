using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//from http://wiki.unity3d.com/index.php/AutoType
public class AutoType : MonoBehaviour {
	
	public float letterPause = 0.01f;
	public SpriteRenderer mouse;
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
		mousePos = new Vector3 (8, -4, -9);
		mouse.transform.position= mousePos;
		mouse.enabled = false;
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
			StartCoroutine (TypeText());
		}

	}
	
	//Draws the text box
	void OnGUI() {
		FontStyle bold;
		GUI.skin.box.wordWrap = true;
		if(choice == false)
		{
			GUI.Box(new Rect(Screen.width - (Screen.width-5), 3*(Screen.height/4)-5, Screen.width - 10, Screen.height/4), message);
			GUI.Box(new Rect(Screen.width - (Screen.width-5), 3*(Screen.height/4)-6*(Screen.height/8), Screen.width/5, Screen.height/10), speaker);
		}
		else if (choice == true)
		{
			if(GUI.Button(new Rect(Screen.width - (Screen.width -5), 3*(Screen.height/4), Screen.width - 10, Screen.height/4/4),list[count].choice))
			{

			}

			if(GUI.Button(new Rect(Screen.width - (Screen.width -5), 3*(Screen.height/4)+Screen.height/4/4, Screen.width - 10, Screen.height/4/4),list[count+1].choice))
			{

			}

			if(GUI.Button(new Rect(Screen.width - (Screen.width -5), 3*(Screen.height/4)+2*(Screen.height/4/4), Screen.width - 10, Screen.height/4/4),list[count+2].choice))
			{

			}

			if(GUI.Button(new Rect(Screen.width - (Screen.width -5), 3*(Screen.height/4)+3*(Screen.height/4/4), Screen.width - 10, Screen.height/4/4),list[count+3].choice))
			{

			}	
		}
		
	}

	IEnumerator TypeText () {
		canClick = false;
		message = "";
		speaker = list[count].speaker;
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
