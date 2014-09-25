using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TwineData{

	public TwineNode current = new TwineNode();

	public TwineNode Current {get{return current;} set{current = value;}}

	public List<TwineNode> Data = new List<TwineNode>();

 	public TwineData(List <string> rawData)
	{
		for (int i = 0; i < rawData.Count; i++)
        {
        	TwineNode twineNode = new TwineNode();
        	Data.Add(twineNode.Parse(rawData[i]));
        }
        current = Data[0];
	}

	 void ShowTwineData(List <string> data)
    {
        bool listedAll = false;

        if (listedAll == false)
        {
            for (int i = 0; i < Data.Count; i++)
            {
                if (i == Data.Count)
                {
                    listedAll = true;
                }

                Debug.Log(Data[i]);
            }
        }
    }

    	public void NextNode()
	{
		for(int i = 0; i > Data.Count; i++)
		{
			if(current.Link == Data[i].Title)
			{
				current = Data[i];
			}
		}
	}

	public void NextNode(string link)
	{
		for(int i = 0; i >Data.Count; i++)
		{
			if(Data[i].Link == link)
			{
				current = Data[i];
			}
		}
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
