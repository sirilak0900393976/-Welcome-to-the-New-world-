using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SetMiniMenu : MonoBehaviour {

    // type text result game
    public static GameObject gScoreBorad;
    public static GameObject gBackHome;
    public static GameObject gPlayAgain;
    public static GameObject gNextScene;
    public GameObject gSetBackHome;
    public GameObject gSetPlayAgain;
    public GameObject gSetNextScene;
    
    // type position button
    Text tScore;
    Text tScore2;
    Text tShowResult;

    float fTime;
    bool bMake;

    // Use this for initialization
    void Start () {
        gScoreBorad = this.gameObject;
        //set basic data
        tShowResult = GameObject.Find("/ScoreBoard(Clone)/Canvas/TextResuts").GetComponent<Text>();
        tScore = GameObject.Find("/ScoreBoard(Clone)/Canvas/TextScore").GetComponent<Text>();
        tScore2  = GameObject.Find("/ScoreBoard(Clone)/Canvas/TextScore2").GetComponent<Text>();
        fTime = 0f;
        bMake = false;

        tShowResult.text = DataGame.sResultGame;
        if (DataGame.sNameScences.Equals("Future"))
        {
            tScore2.text = "+" + DataGame.nScoreGame;
            tScore.text = "" + (DataGame.nScoreGame + gameManager.nScore);
        }
        else
        {
            tScore2.text = "";
            tScore.text = "" + DataGame.nScoreGame;
        }
        
    }

    void Update()
    {
        if (fTime <= 3f)
        {
            fTime += Time.deltaTime;
        }
        
        if (fTime <= 0.5f)
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = this.transform.up * 2;
        }
        else if (fTime <= 0.3f)
        {
            this.GetComponent<Rigidbody>().velocity = this.transform.up * 0;
        }
        else if (fTime <= 1.7f)
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = this.gameObject.transform.forward * -2;
        }
        else
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = this.gameObject.transform.up * 0;
        }

        if (fTime >= 1.3f && !bMake) {
            //Debug.Log(DataGame.sResultGame + "  " + SceneManager.GetActiveScene().name);
            if (DataGame.sResultGame.Equals("Game Over") || SceneManager.GetActiveScene().name.Equals("Future"))
            {
                gBackHome = Instantiate(gSetBackHome);
                gPlayAgain = Instantiate(gSetPlayAgain);
                if (DataGame.sNameScences.Equals("Future"))
                {
                    gBackHome.transform.position = new Vector3(83.21559f, -2.949182f, 98.29472f);
                    gPlayAgain.transform.position = new Vector3(84.66f, -2.98f, 98.53f);
                }
            }
            else if (DataGame.sResultGame.Equals("You Win") && !SceneManager.GetActiveScene().name.Equals("Future"))
            {
                gBackHome = Instantiate(gSetBackHome);
                gPlayAgain = Instantiate(gSetPlayAgain);
                gNextScene = Instantiate(gSetNextScene);
            }
            bMake = true;
        }
    }


}
