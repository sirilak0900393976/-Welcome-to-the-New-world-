using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class FunctionHTP : MonoBehaviour {
    public GameObject gPFCountDown;
    public GameObject gButton;
    public GameObject gButtonBackHome;
    public GameObject gButtonPlayagain;
    public AudioSource asSource;
    public AudioClip acPlay;
    public static string sControSong;
    string[] sDescription = new string[] { "ใช้ดาบด้านซ้ายหรือ\nด้านขวาฟันปุ่มที่อยู่\nด้านหน้าเพื่อเริ่มต้น\nการสอน",
        "จะต้องฟันมอสเตอร์ เพื่อไม่ให้ค่าพลังชีวิตลดลง",
        "มอนเตอร์ สามารถปรากฎได้ 1 - 2 ตัว ต่อครั้ง",
        "ในเกมจะมีอุปสรรค ที่เป็นวัตถุสีแดง ถ้าผู้เล่นสัมผัสค่าพลังชีวิตจะลดลง",
        "คุณพร้อมสำหรับการ เล่นเกมจริงแล้ว!"};
    string[] sButton = new string[] { "เริ่มต้น","เล่นต่อ","เมนูหลัก"};
    Text tTime, tMainHTP, tButton;
    public static int nStep, nCountMonster;
    public static bool bTime, bStep, bContro;
    public static float fTime;
    public static bool regame;
    public static bool playgame;
    //public static float fPlayer;

    void Start () {
        playgame = true;
        bContro = false;
        bTime = true;
        bStep = false;
        asSource.clip = acPlay;
        asSource.Play();
        GameObject Buttonset = Instantiate(gButton);
        Debug.Log(Buttonset.name);
        Instantiate(gButtonBackHome);
        Instantiate(gButtonPlayagain);
        fTime = 0f;
        nStep = 0;
        nCountMonster = 0;
        //fPlayer = GameObject.Find("/Player").transform.position.z;
        tTime = GameObject.Find("/CheckTest/Time").GetComponent<Text>();
        tMainHTP = GameObject.Find("/Description/Text").GetComponent<Text>();
        tButton = GameObject.Find("Button(Clone)/Canvas/Text").GetComponent<Text>();
        
        tButton.text = sButton[0];
        tMainHTP.text = sDescription[0];
    }
	
	void Update () {
        if (!playgame & regame)
        {
            playgame = true;
            tMainHTP.text = "";
            tTime.text = "Time : 0:0";
            GameObject gButton = Instantiate(gButtonPlayagain);
            tButton = GameObject.Find("ButtonPlayagain(Clone)/Canvas/Text").GetComponent<Text>();
            gButton.gameObject.name = "Check";
            tButton.text = "เล่นใหม่อีกครั้ง";
            Debug.Log(tButton.gameObject.name);
        }
        if (!playgame & !regame)
        {
            Debug.Log("ResetGame");
            playgame = true;
            bContro = false;
            bTime = true;
            bStep = false;
            asSource.Stop();
            asSource.clip = acPlay;
            asSource.Play();
            Instantiate(gButton);
            Instantiate(gButtonBackHome);
            Instantiate(gButtonPlayagain);
            fTime = 0f;
            nStep = 0;
            nCountMonster = 0;
            tTime = GameObject.Find("/CheckTest/Time").GetComponent<Text>();
            tMainHTP = GameObject.Find("/Description/Text").GetComponent<Text>();
            tButton = GameObject.Find("Button(Clone)/Canvas/Text").GetComponent<Text>();
            tButton.text = sButton[0];
            tMainHTP.text = sDescription[0];

        }
        else if (playgame && !regame)
        {
            FuncControSong();
            FuncCheckStep();
            if (bTime)
            {
                fTime += Time.deltaTime;
                tTime.text = "Time : " + ((int)(fTime / 60)) + ":" + ((int)(fTime % 60));
            }
        }

    }

    void FuncControSong() {
        if (bContro)
        {
            if (sControSong.Equals("pause"))
            {
                asSource.Pause();
            }
            else if (sControSong.Equals("play"))
            {
                asSource.UnPause();
            }
            sControSong = "";
            bContro = false;
        }
    }

    void FuncCheckStep() {
        if (bStep)
        {
            Debug.Log("in Function : " + nStep);
            if (nStep == 1)
            {
                GameObject gCountDown = Instantiate(gPFCountDown);
                gCountDown.transform.position = new Vector3(11.9f, 80.65f, 500.18f);
            }
            else if (nStep == 2)
            {
                GameObject gMake = Instantiate(gButton);
                tButton = GameObject.Find("Button(Clone)/Canvas/Text").GetComponent<Text>();
                tButton.text = sButton[1];
                tMainHTP.text = sDescription[1];
            }
            else if (nStep == 4)
            {
                GameObject gMake = Instantiate(gButton);
                tButton = GameObject.Find("Button(Clone)/Canvas/Text").GetComponent<Text>();
                tButton.text = sButton[1];
                tMainHTP.text = sDescription[2];
            }
            else if (nStep == 6)
            {
                GameObject gMake = Instantiate(gButton);
                tButton = GameObject.Find("Button(Clone)/Canvas/Text").GetComponent<Text>();
                tButton.text = sButton[1];
                tMainHTP.text = sDescription[3];
            }
            else if (nStep == 8)
            {
                GameObject gMake = Instantiate(gButton);
                tButton = GameObject.Find("Button(Clone)/Canvas/Text").GetComponent<Text>();
                tButton.text = sButton[2];
                tMainHTP.text = sDescription[4];
            }
            else if (nStep == 9)
            {
                fTime = 0f;
                nStep = 0;
                RandomSample.nIndex = 0;
                SceneManager.LoadScene("Home game");
            }
            bStep = false;
        }
    }
}
