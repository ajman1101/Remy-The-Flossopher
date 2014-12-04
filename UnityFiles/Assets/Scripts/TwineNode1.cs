using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TwineNode1
{
	string passage;
	string content;
	string speaker;
	List<string> linkTitles = new List<string>();
	List<string> links = new List<string>();
	string nextPassage;

	public string Passage {get{return passage;} set{passage = value;}}
	public string Content {get{return content;} set{content = value;}}
	public string Speaker {get{return speaker;} set{speaker = value;}}
	
	public List<string> LinkTitle 
	{
		get
		{
			/*foreach(string s in linkTitles)
			{/*
				if(s == data)
				{
					return s;
				}
				return s;
			}
			return null;*/
			return linkTitles;
		}
	}

	public string LinkTitleData
	{
		get
		{
			if(linkTitles.Count > 1)
			{
				foreach(string s in linkTitles)
				{
					return s;
				}
				return null;
			}
			else
			{
				return linkTitles[0];
			}
		}
	}

	/*
	public string Link()
	{
		get:
		{
			return links[0];
		}
	}*/

	public string Link
	{
		get{
			foreach(string s in links)
			{/*
				if(s == data)
				{
					return s;
				}*/
				return s;
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
                Debug.Log("Title: " + LinkTitleData + "\n Link: " + Link);
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

	public TwineNode1(string data, char split)
	{
		if (data.IndexOf("[[") != -1)
		{
			int startTitle = data.IndexOf("[[") + 2;
			int endTitle = data.IndexOf("|");
			linkTitles.Add(data.Substring(startTitle, endTitle - startTitle));
			int startLink = data.IndexOf("|") + 1;
			int endLink = data.IndexOf("]]");
			links.Add(data.Substring(startLink, endLink - startLink));
			Debug.Log("Title: " + LinkTitleData + "\n Link: " + Link);
		}
		if (data.Length == 0)
		{
			Debug.Log("Blank: " + data);
		}
		if (data.IndexOf ("::") != -1 && data.IndexOf("[[") != -1)
		{
			int startPassage = data.IndexOf ("::") + 2;
			int endPassage = data.IndexOf ("\r\n");
			passage = data.Substring (startPassage, endPassage);
			Debug.Log ("Start of Passage: " + passage);

			int endContent = data.IndexOf ("[[");
			string tempContent = data.Substring(endPassage, endContent - endPassage);
			string[] temp = tempContent.Split (split);
			Debug.Log (temp.Length);
			if (temp.Length > 1 && temp.Length < 3)
			{
				speaker = temp [0];
				content = temp [1];
				Debug.Log ("Speaker: " + speaker);
			} 
			else 
			{
				content = tempContent;
			}
			Debug.Log ("Content: " + content);
		}
	}
}