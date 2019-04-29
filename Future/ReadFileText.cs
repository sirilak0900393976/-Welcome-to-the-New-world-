using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System;

public class ReadFileText : MonoBehaviour
{

    void CreateText()
    {
        //Path of the file
        string path = Application.dataPath + "/Log.txt";
        //Create File if it doesn't exist
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "Login log \n\n");
        }
        //content of the file
        //string content = "Login date: " + System.DataTime.Now + "\n";
        string content = "Test \n";
        //Add som to text to it
        File.AppendAllText(path,content);
    }

    // Use this for initialization
    void Start()
    {
        CreateText();
    }

}
