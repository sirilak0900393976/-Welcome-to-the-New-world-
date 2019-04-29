using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountDown : MonoBehaviour {

    float fTime;
    TextMesh tCountDown;
    string sText;
    bool checkscence = false;
    // Use this for initialization
    void Start () {
        if (!SceneManager.GetActiveScene().name.Equals("How to play game"))
        {
            fTime = 5f;
            tCountDown = this.GetComponent<TextMesh>();

        }
        else
        {
            checkscence = true;
            fTime = 3.1f;
            FunctionHTP.bContro = true;
            FunctionHTP.sControSong = "pause";
            tCountDown = this.GetComponent<TextMesh>();
        }
        
    }
	
	// Update is called once per frame
	void Update () {
        
        if (checkscence && FunctionHTP.regame)
        {
            Destroy(this.gameObject);
        }
        if (fTime > 1f)
        {
            fTime -= Time.deltaTime;
            //PlaySong.TimeSong += Time.deltaTime;
            sText = fTime.ToString("####0");
            tCountDown.text = "" + sText;
        }
        else {
            if (!checkscence)
            {
                DataGame.bPlaySong = true;
            }
            else
            {
                FunctionHTP.bContro = true;
                FunctionHTP.sControSong = "play";
            }
            
            Destroy(this.gameObject);
        }
	}
}
