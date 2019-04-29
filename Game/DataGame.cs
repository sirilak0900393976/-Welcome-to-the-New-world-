using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class DataGame : MonoBehaviour {

    //type for score
    public static int nScoreGame;
    public static int nScoreHit;
    public static int nCombo;
    public static int nLife;

    public static int nHit;
    public static bool bHit;
    public static bool bHitFail;
    
    public static int nTotalSelect; // Save id Select index ex. use SelectIndex3 -> TotalSelect = 3 // ex use 5 and 4 = 9

    //type end game
    public static bool bEndGame;
    public static bool bReGame;
    public static bool bPlayGame;
    public static string sResultGame;
    
    //Type Check Song for function
    public static bool bPlaySong;
    public static float fTimeSong;

    public static Vector3 vSetMiniMenu2;

    public static int nIndexIF;
    public static int nCountMonster;
    public static string sNameScences;

    //2.413555 2.516584 0.061699
    // Use this for initialization
    void Start () {

        nScoreHit = 0;
        nScoreGame = 0;
        nLife = 5;
        nCombo = 0;
        nIndexIF = 0;
        nCountMonster = 0;
        nTotalSelect = 0;
        
        bEndGame = false;
        bReGame = false;
        bPlayGame = true;

        nHit = 0;
        nCombo = 0;
        bHit = false;
        bHitFail = false;

        sResultGame = "";
        
        bPlaySong = false;
        fTimeSong = 0f;
        vSetMiniMenu2 = new Vector3(84.6855f, -2.230182f, 101.6947f);
        sNameScences = SceneManager.GetActiveScene().name;

        //test
        //sNameScences = "Future";
    }
	
}
