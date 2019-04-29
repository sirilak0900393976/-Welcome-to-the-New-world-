using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class BT_MiniMenu : MonoBehaviour {
    public GameObject gCountDown;
    private void OnCollisionEnter(Collision collision)
    {
        FunctionMiniMenu(collision);
    }

    private void OnCollisionStay(Collision collision)
    {
        FunctionMiniMenu(collision);
    }


    void FunctionMiniMenu(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        Debug.Log(this.gameObject.name);
        if (collision.gameObject.tag == "sword_left" ||
            collision.gameObject.tag == "sword_right")
        {
            if (this.gameObject.name.Equals("BackHome(Clone)"))
            {
                BackHome();
            }
            else if (this.gameObject.name.Equals("PlayAgain(Clone)"))
            {
                PlayAgain();
            }
            else if (this.gameObject.name.Equals("NextScene(Clone)"))
            {
                NextGame();
            }
        }
    }

    void BackHome()
    {
        int nTotalScore = DataGame.nScoreGame + gameManager.nScore;
        DataBase DB = this.gameObject.GetComponent<DataBase>();
        bool[] bData = DB.Readers(nTotalScore);
        if (bData[0] && !bData[1])
        {
            DB.Insertvalue(nTotalScore, gameManager.sNamePlayer);
        }
        else if (bData[0])
        {
            DB.Insertvalue(nTotalScore, gameManager.sNamePlayer);
            DB.Deletvalue();
        }
        SceneManager.LoadScene("Home game");
        Destroy(SetMiniMenu.gScoreBorad);
        if (DataGame.sResultGame.Equals("You Win") && !DataGame.sNameScences.Equals("Future"))
            Destroy(SetMiniMenu.gNextScene);
        else if (DataGame.sResultGame.Equals("Game Over") || DataGame.sNameScences.Equals("Future"))
            Destroy(SetMiniMenu.gPlayAgain);
        Destroy(this.gameObject);
    }

    void NextGame()
    {
        gameManager.nScore = DataGame.nScoreGame;
        SceneManager.LoadScene("Future");
        Destroy(SetMiniMenu.gScoreBorad);
        Destroy(SetMiniMenu.gBackHome);
        Destroy(SetMiniMenu.gPlayAgain);
        Destroy(this.gameObject);
    }

    void PlayAgain()
    {
        DataGame.bPlayGame = true;
        DataGame.bReGame = true;
        DataGame.fTimeSong = 0f;
        PlaySong.bStopSong = false;
        GameObject MakeCountDown = Instantiate(gCountDown);
        if (SceneManager.GetActiveScene().name.Equals("Future"))
        {
            MakeCountDown.transform.position = new Vector3(84.65f, 2.11f, 103.71f);
        }
        Debug.Log(SceneManager.GetActiveScene().name);
        Destroy(SetMiniMenu.gScoreBorad);
        Destroy(SetMiniMenu.gBackHome);
        if (DataGame.sResultGame.Equals("You Win") && !DataGame.sNameScences.Equals("Future"))
            Destroy(SetMiniMenu.gNextScene);
        Destroy(this.gameObject);
    }
}
