using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TwineNode1
{
	string passage;
	string content;
	List<string> linkTitles = new List<string>();
	List<string> links = new List<string>();
	string nextPassage;

	public string Passage {get{return passage;} set{passage = value;}}
	public string Content {get{return content;} set{content = value;}}
	
	public string LinkTitle(string data) 
	{
		get:
		{
			foreach(string s in linkTitles)
			{
				if(s == data)
				{
					return s;
				}
			}
			return null;
		}
	}

	public string Link()
	{
		get:
		{
			return links[0];
		}
	}

	public string Link(string data)
	{
		get:{
			foreach(string s in links)
			{
				if(s == data)
				{
					return s;
				}
			}
			return null;
		}
	}

	public string NextPassage {get{return nextPassage;} set{nextPassage = value;}}

	public TwineNode1(string data)
	{
		if (data.IndexOf("[[") != -1)
            {
                int startTitle = data.IndexOf("[[") + 2;
                int endTitle = data.IndexOf("|");
                linkTitles.Add(data.Substring(startTitle, endTitle - startTitle));
                int startLink = data.IndexOf("|") + 1;
                int endLink = data.IndexOf("]]");
                links.Add(data.Substring(startLink, endLink - startLink));
                Debug.Log("Title: " + title + "\n Link: " + link);
            }
        if (data.Length == 0)
            {
                Debug.Log("Blank: " + data);
            }
        if (data.IndexOf("::") != -1)
            {
                int startPassage = data.IndexOf("::") + 2;
                passage = data.Substring(startPassage);
                Debug.Log("Start of Passage: " + passage);
            }
        else if (data.IndexOf("[[") == -1 && data.Length != 0)
            {
            	content = data;
            	Debug.Log("Content: "+content);
            }
	}
}