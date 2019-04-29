using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSample : MonoBehaviour {
    Dictionary<string, string> dicRandomPosition = new Dictionary<string, string>();
    public static int nPositionMonster = 9;
    public static int nPositionBox = 9;
    public static int nRandomPrefab = 0;
    public GameObject[] poMakeMonster = new GameObject[9];
    public GameObject[] poMakeBox = new GameObject[3];
    public GameObject[] prefabMonster = new GameObject[3];
    public GameObject prefabBox;
    public Vector3[] vEditMonster = new Vector3[3];
    public Vector3 vEditBox;
    Vector3 vEditPosition;
    //float[] floatSong = new float[] {4.208f, 7.976f, 8.912f, 9.620f,
    //                    10.308f, 11.704f, 12.644f, 13.352f, 14.060f,
    //                    15.452f, 16.415f, 17.163f, 17.815f, 19.223f };
    public static int nIndex = 0;
    // Use this for initialization
    float TimeMakeNow;
    int CountMake;
    void Start () {
        AddDataPosition();
        TimeMakeNow = gameManager.fCheckIF2[0];
        CountMake = 0;
        
    }
	
	// Update is called once per frame
	void Update () {
        if (FunctionHTP.regame)
        {
            nPositionMonster = 9;
            nPositionBox = 9;
            nRandomPrefab = 0;
            nIndex = 0;
            TimeMakeNow = gameManager.fCheckIF2[0];
            CountMake = 0;
        }


        if (FunctionHTP.bTime && nIndex < gameManager.fCheckIF2.Length) {
            if (Mathf.Abs(FunctionHTP.fTime - gameManager.fCheckIF2[nIndex]) < 0.075)
            {
                if (FunctionHTP.fTime - TimeMakeNow > 1f)
                {
                    TimeMakeNow = FunctionHTP.fTime;
                    if (CountMake <= 10)
                    {
                        RandomMonster(9);
                    }
                    else if (CountMake == 11)
                    {
                        RandomMonster(9);
                        RandomMonster(nPositionMonster);
                        FunctionHTP.nStep += 1;
                        FunctionHTP.bStep = true;
                        Debug.Log("Secondmonster" + FunctionHTP.nStep);
                    }
                    else if (Random.Range(0, 3) != 2)
                    {
                        RandomMonster(9);
                    }
                    else
                    {
                        RandomMonster(9);
                        RandomMonster(nPositionMonster);
                    }

                    nIndex += 1;
                    CountMake += 1;
                    if (CountMake == 3)
                    {
                        FunctionHTP.nStep += 1;
                        FunctionHTP.bStep = true;
                        Debug.Log("firstmonster" + FunctionHTP.nStep);
                    }
                    if (CountMake == 21)
                    {
                        nPositionBox = 0;
                        GameObject gBoxSet = Instantiate(prefabBox);
                        vEditPosition = poMakeBox[0].transform.position;
                        gBoxSet.transform.position = new Vector3(vEditPosition.x + vEditBox.x, vEditPosition.y + vEditBox.y, vEditPosition.z + vEditBox.z);
                        FunctionHTP.nStep += 1;
                        FunctionHTP.bStep = true;
                        Debug.Log("Makebox" + FunctionHTP.nStep);
                    }
                }
                else
                {
                    nIndex += 1;
                }
                
            }
        }
        else if ((nIndex == gameManager.fCheckIF2.Length) && FunctionHTP.nCountMonster == 0 && FunctionHTP.nStep < 8)
        {
            FunctionHTP.nStep += 1;
            FunctionHTP.bStep = true;
            Debug.Log("end game"+ FunctionHTP.nStep);
        }
        
	}

    void AddDataPosition()
    {
        dicRandomPosition.Add("99", "0,1,2,3,4,5,6,7,8");
        dicRandomPosition.Add("90", "1,2,4,5,7,8");
        dicRandomPosition.Add("92", "0,1,3,4,6,7");

        dicRandomPosition.Add("09", "1,3,4");
        dicRandomPosition.Add("19", "0,2,3,4,5");
        dicRandomPosition.Add("29", "1,4,5");
        dicRandomPosition.Add("39", "0,1,4,6,7");
        dicRandomPosition.Add("49", "0,1,2,3,5,6,7,8");
        dicRandomPosition.Add("59", "1,2,4,7,8");
        dicRandomPosition.Add("69", "3,4,7");
        dicRandomPosition.Add("79", "3,4,5,6,8");
        dicRandomPosition.Add("89", "4,5,7");

        dicRandomPosition.Add("10", "2,4,5");
        dicRandomPosition.Add("20", "1,4,5");
        dicRandomPosition.Add("40", "1,2,5,7,8");
        dicRandomPosition.Add("50", "1,2,4,7,8");
        dicRandomPosition.Add("70", "4,5,8");
        dicRandomPosition.Add("80", "4,5,7");

        dicRandomPosition.Add("02", "1,3,4");
        dicRandomPosition.Add("12", "0,3,4");
        dicRandomPosition.Add("32", "0,1,4,6,7");
        dicRandomPosition.Add("42", "0,1,3,6,7");
        dicRandomPosition.Add("62", "3,4,7");
        dicRandomPosition.Add("72", "3,4,6");
    }

    void RandomMonster(int nIndextFrist)
    {
        nRandomPrefab = Random.Range(0,3);
        string[] Data = dicRandomPosition[""+nIndextFrist+nPositionBox].Split(',');
        nPositionMonster = int.Parse(Data[Random.Range(0,Data.Length)]);
        GameObject gMonsterSet = Instantiate(prefabMonster[nRandomPrefab]);
        vEditPosition = poMakeMonster[nPositionMonster].transform.position;
        gMonsterSet.transform.position = new Vector3(vEditPosition.x + vEditMonster[nRandomPrefab].x,
            vEditPosition.y + vEditMonster[nRandomPrefab].y, vEditPosition.z + vEditMonster[nRandomPrefab].z);
        FunctionHTP.nCountMonster += 1;
    }
}
