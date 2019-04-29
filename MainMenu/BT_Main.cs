using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BT_Main : MonoBehaviour {

    public GameObject gKeyBoard; // ButtonEditName
    public GameObject gAlert;
    public GameObject gPlayer;


    private void OnTriggerEnter(Collider other)
    {
        FunctionBT_Main(other);
    }

    private void OnTriggerStay(Collider other)
    {
        FunctionBT_Main(other);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!DataMenu.bCreateName)
        {
            this.gameObject.GetComponent<Renderer>().material = DataMenu.mMain[0];
        }
    }


    //================================================================================================


    void FunctionBT_Main(Collider other)
    {
        if (!DataMenu.bCreateName && !DataMenu.bMakeAlert)
        {
            if (DataMenu.CheckTriger(other))
            {
                GetComponent<Renderer>().material = DataMenu.mMain[2];
                if (this.gameObject.name.Equals("ButtonCreateName"))
                {
                    MakeKeyBoard();
                }
                else if (this.gameObject.name.Equals("ButtonPlay"))
                {
                    PlayGame();
                }
                else if (this.gameObject.name.Equals("ButtonQuit"))
                {
                    Application.Quit();
                }
                else if (this.gameObject.name.Equals("ButtonHTP"))
                {
                    //Destroy(gPlayer.gameObject);
                    SceneManager.LoadScene("How to play game");
                }
            }
            else
            {
                this.gameObject.GetComponent<Renderer>().material = DataMenu.mMain[1];
            }
        }
           
    }

    void MakeKeyBoard()
    {
        DataMenu.bCreateName = true;
        DataMenu.gKeyBoard = Instantiate(gKeyBoard);
        DataMenu.tMakeName = GameObject.Find("/TextKeyBoard(Clone)/Name/Text").GetComponent<Text>();
        DataMenu.tMakeName.text = DataMenu.tName.text;
    }

    void PlayGame()
    {
        if (!DataMenu.tName.text.Equals(""))
        {
            gameManager.sNamePlayer = DataMenu.tName.text;
            gameManager.nMakeIf = 1;
            SceneManager.LoadScene("Forest");
        }
        else
        {
            GetComponent<Renderer>().material = DataMenu.mMain[1];
            DataMenu.bMakeAlert = true;
            Instantiate(gAlert);
        }
    }
}
