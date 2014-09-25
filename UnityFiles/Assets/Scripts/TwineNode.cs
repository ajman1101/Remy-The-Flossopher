using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TwineNode{

	string title;
	string passage; 
	string link;
	string content;


	public string Title { get{return title;} set{title = value;}}
	public string Passage {get{return passage;} set{passage = value;}}
	public string Link {get{return link;} set{link = value;}}
	public string Content {get{return content;} set{content = value;}}

	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public TwineNode Parse(string data)
	{
		if (data.IndexOf("[[") != -1)
            {
                int startTitle = data.IndexOf("[[") + 2;
                int endTitle = data.IndexOf("|");
                title = data.Substring(startTitle, endTitle - startTitle);
                int startLink = data.IndexOf("|") + 1;
                int endLink = data.IndexOf("]]");
                link = data.Substring(startLink, endLink - startLink);
                //Debug.Log("Title: " + title + "\n Link: " + link);
            }
        if (data.Length == 0)
            {
                //Debug.Log("Blank: " + data);
            }
        if (data.IndexOf("::") != -1)
            {
                int startPassage = data.IndexOf("::") + 2;
                passage = data.Substring(startPassage);
                //Debug.Log("Start of Passage: " + passage);
            }
        else if (data.IndexOf("[[") == -1 && data.Length != 0)
            {
            	content = data;
            	//Debug.Log("Content: "+content);
            }
            
    	return  this;
	}

	// public void NextNode(List <TwineNode> Data)
	// {
	// 	for(int i = 0; i > Data.Count; i++)
	// 	{
	// 		if(Data.Current.Link == Data[i].Title)
	// 		{
	// 			Data.Current = Data[i];
	// 		}
	// 	}
	// }

	// public void NextNode(List <TwineNode> Data, string link)
	// {
	// 	for(int i = 0; i >Data.Count; i++)
	// 	{
	// 		if(Data[i].link == link)
	// 		{
	// 			Data.Current = Data[i];
	// 		}
	// 	}
	// }
}
