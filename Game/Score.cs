using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    //type text game
    Text tScore;
    Text tCombo;
    Text tLife;
    
    //type for make sound fx for hit
    public AudioClip acShootSound;
    public AudioSource asSource;
    
    //type end game
    public GameObject gMenuEndGame;
    bool bEndGame;
    

    // Use this for initialization
    void Start () {
        //set basic value
        tScore = GameObject.Find("/CanvasScore/Score").GetComponent<Text>();
        tCombo = GameObject.Find("/CanvasScore/Combo").GetComponent<Text>();
        tLife = GameObject.Find("/CanvasLife/Life").GetComponent<Text>();
        asSource = GetComponent<AudioSource>();

        tLife.text = "" + 5;
        tScore.text = "" + 0;
        tCombo.text = "";
        bEndGame = false;

    }
	
	// Update is called once per frame
	void Update () {

        //function regame
        if (!DataGame.bPlayGame && !bEndGame) //make mini menu
        {
            GameObject gMakeMiniMenu = Instantiate(gMenuEndGame); ;
            bEndGame = true;
            if (SceneManager.GetActiveScene().name.Equals("Future"))
            {
                Debug.Log(DataGame.sNameScences);
                gMakeMiniMenu.transform.position = DataGame.vSetMiniMenu2;
            }
        }
        if (DataGame.bReGame) // set basic value
        {
            bEndGame = false;
            DataGame.bReGame = false;
            tScore.text = "" + 0;
            tLife.text = "" + 5;
            tCombo.text = "";
            DataGame.sResultGame = "";
            DataGame.nLife = 5;
            DataGame.bHit = false;
            DataGame.bHitFail = false;
            DataGame.nHit = 0;
            DataGame.nScoreGame = 0;
        }

        //function score
        if (DataGame.bHit) {
            DataGame.bHit = false;
            asSource.PlayOneShot(acShootSound, 0.5f);

            DataGame.nCombo = DataGame.nHit / 5;
            if (DataGame.nHit >= 5) { // reset life full
                DataGame.nLife = 5;
                tLife.text = "" + DataGame.nLife;
            }
            if (DataGame.nCombo >= 8){ // max combo 
                DataGame.nCombo = 8;
            }

            //set score and write text
            DataGame.nScoreHit = 10 + DataGame.nCombo * 10;
            DataGame.nScoreGame += DataGame.nScoreHit;
            tScore.text = "" + DataGame.nScoreGame;
            //gameManager.nScore += DataGame.ScoreHit;
            //tScore.text = "" + gameManager.nScore;
            if (DataGame.nCombo == 0)
            {
                tCombo.text = "";
            }
            else
            {
                tCombo.text = "" + DataGame.nCombo;
            }
            
        }
        else if(DataGame.bHitFail){
            DataGame.bHitFail = false;
            DataGame.nScoreHit = 0;
            tCombo.text = "";
            tLife.text = "" + DataGame.nLife;
            if (DataGame.nLife <= 0) // game over
            {
                tLife.text = "" + 0;
                DataGame.sResultGame = "Game Over";
                DataGame.bPlayGame = false;
            }

        }
    }
    
}
