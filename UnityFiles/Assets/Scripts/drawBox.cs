using UnityEngine;
using System.Collections;

public class drawBox : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI() {
		GUI.Box(new Rect(5, 440, Screen.width - 10, Screen.height/4),"WAT?");
	}
}
