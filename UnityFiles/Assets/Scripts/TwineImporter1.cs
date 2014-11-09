using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

public class TwineImporter1 
{

    // Use this for initialization
    List<string> twineData = new List<string>();

    public TwineImporter1()
    {
        string path = Application.dataPath + @"\Resources\dialogue.txt";
        ReadTwineData(path);
        ShowTwineData(twineData);

    }

    public void ReadTwineData(string path)
    {
        string temp;
        string[] file;
		string[] split = {"::"};

        try
        {
            //create a stream reader
            //get the data in the text file
            //close the stream reader
            StreamReader sr = new StreamReader(path);
            temp = sr.ReadToEnd();
            sr.Close();

            //parse large string by lines into an list
			file = temp.Split(split, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in file)
            {
                twineData.Add(s);
            }
        }

        catch (FileNotFoundException e)
        {
            Debug.Log("The process failed: {0}" + e.ToString());
            return;
        }
    }

    void ShowTwineData(List <string> data)
    {
        for (int i = 0; i < data.Count; i++)
        {
            Debug.Log("Data Set "+i+": "+ data[i]);
        }
    }

	/*
    public void ParseTwineData(List<string> data)
    {
    	for (int i = 0; i < data.Count; i++)
        {
            TwineNode1 twineNode = new TwineNode1(data[i]);
			//twineData.Add(twineNode.Parse(rawData[i]));
        }
		//current = twineData[0];
    }*/

    // Update is called once per frame
    void Update()
    {


    }


}