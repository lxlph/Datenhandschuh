﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadCSV : MonoBehaviour
{
    private string fieldSeperater = ";";
    private string lineSeperater = "\n";
    private string fileData;
    private string path;
    private string [] lines;
    private string[] lineHeader;
    private float x;

    void Awake()
    {
        fieldSeperater = ";";
        //fieldSeperater = ",";
        path = Application.dataPath + "/SavedData.csv";
        //path = Application.dataPath + "/drehung1_daten.csv";
        fileData = System.IO.File.ReadAllText(path);
        lines = fileData.Split("\n"[0]);
        lineHeader = (lines[0].Trim()).Split(fieldSeperater[0]);
        //print header
        PrintLine(0);

    }

    public int CountLines()
    {
        return lines.GetLength(0);
    }

    private void PrintLine(int index)
    {
        string output = string.Join(", ",
             new List<string>(GetLineValues(index))
             .ConvertAll(i => i.ToString())
             .ToArray());
        Debug.Log(output);
    }

    public string[] GetLineValues(int index)
    {
        string[] line = (lines[index].Trim()).Split(fieldSeperater[0]);
        return line;
    }

    public int GetIndexOf(string name)
    {
        int index = 0;
        for (int i = 0; i < lineHeader.Length; i++)
        {
            if (lineHeader[i].Equals(name))
            {
                index = i;
                break;
            }
        }
        return index;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
