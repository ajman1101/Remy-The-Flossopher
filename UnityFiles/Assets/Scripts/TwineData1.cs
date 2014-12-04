using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TwineData1
{
	public List<TwineNode1> Data = new List<TwineNode1>();
	TwineNode1 current;

	public TwineData1(List <string> data)
	{
		for(int i = 0; i < data.Count; i++)
		{
			TwineNode1 twineNode = new TwineNode1(data[i]);
			Data.Add(twineNode);

			if(i == 0)
			{
				current = twineNode;
			}
		}
	}
	public TwineData1(List <string> data, char split)
	{
		for(int i = 0; i < data.Count; i++)
		{
			TwineNode1 twineNode = new TwineNode1(data[i], split);
			Data.Add(twineNode);
			
			if(i == 0)
			{
				current = twineNode;
			}
		}
	}

	//go to next node
	public void NextNode()
	{
		for(int i = 0; i < Data.Count; i++)
		{
			if(current.Link == Data[i].Passage)
			{
				current = Data[i];
			}
		}
	}

	//go to specific node
	public void NextNode(string link)
	{
		Debug.Log ("hello: " + current.Link);
		for(int i = 0; i < Data.Count; i++)
		{
			Debug.Log("HI: " + Data[i].Passage);
			if(current.Link == Data[i].Passage)
			{
				current = Data[i];
			}
		}
	}

	public TwineNode1 Current
	{
		get
		{
			return current;
		}
	}
}