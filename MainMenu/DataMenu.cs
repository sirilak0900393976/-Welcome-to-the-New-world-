using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class DataMenu : MonoBehaviour {

    //type color button mainmenu
    public Material[] mMainSet = new Material[3];
    //=========================================
    public static Material[] mMain = new Material[3];

    //type color button keyboard;
    public Material[] mKeyBoardSet = new Material[3];
    //=========================================
    public static Material[] mKeyBoard = new Material[3];

    //type bool for gameobject
    public static bool bCreateName;
    public static bool bLeftHand;
    public static bool bRightHand;
    public static bool bMakeAlert;

    //use in prefab button keyboard
    public GameObject gSelectEditSet;
    public static GameObject gSelectEdit;
    public static Text tName;

    public static GameObject gKeyBoard;
    public static Text tMakeName;

    // Use this for initialization
    void Start () {
        // set for use all file
        for (int i = 0; i < mMain.Length; i++)
        {
            mMain[i] = mMainSet[i];
            mKeyBoard[i] = mKeyBoardSet[i];
        }

        bCreateName = false;
        bLeftHand = false;
        bRightHand = false;
        bMakeAlert = false;
        
        //use in prefab button keyboard
        gSelectEdit = gSelectEditSet;
        tName = GameObject.Find("/MainMenu/TextMenu/NameWord").GetComponent<Text>();
        tName.text = "";
        
        //set data gameMeager
        gameManager.nScore = 0;
        gameManager.sNamePlayer = "";
        
    }

    public static bool CheckTriger(Collider other)
    {
        bool bCheckTriger = false;
        if (other.gameObject.tag == "sword_left" && bLeftHand)
        {
            bCheckTriger = true;
        }
        else if (other.gameObject.tag == "sword_right" && bRightHand)
        {
            bCheckTriger = true;
        }
        return bCheckTriger;
    }

}
