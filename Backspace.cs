using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Backspace : MonoBehaviour {

    // input with unity 
    public Text myName = null;
    public Text index = null;

    // Use this for initialization
    string word = null;
    int wordIndex = -1;
    
    string[] name = new string[10];
    

    public void nameFunc(string alphabet) {
        wordIndex++;
        if (wordIndex < name.Length)
        {
            name[wordIndex] = alphabet;
            word = word + alphabet;
            myName.text = word;
            index.text = "" + wordIndex;
        }
        else
        {
            wordIndex--;
        }
        
    }
    public void backspaceFunction() {
        if (wordIndex >= 0)
        {
            wordIndex--;
            word = null;
            for (int i = 0; i < wordIndex + 1; i++) {
                word += name[i];
                
            }
            myName.text = word;
            index.text = "" + wordIndex;
        }
    }
}
