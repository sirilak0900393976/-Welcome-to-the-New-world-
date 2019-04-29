
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomMonster : MonoBehaviour {

    //input data with unity.
    public GameObject[] gPrefab;
    public GameObject[] gPositionMake;
    float[] fValueIf;
    public float[] fEditPositionY;
    public float[] fEditPositionX;
    int nRandomPrefab;
    public static int nRandomPosition;
    Vector3 vSavePosition;
    //All index for Monster Row 2 in 1 Second.
    string[] sSelectIndex = { "1 3 4", "0 2 3 4 5", "1 4 5",
                             "0 1 4 6 7", "0 1 2 3 5 6 7 8","1 2 4 7 8",
                             "3 4 7", "3 4 5 6 8", "4 5 7"};
    //---------------------------------------------------------
    //array string SelectIndex2 Up use with BoxTime.
    string[,] sSelectIndexBox1 = {{ "1 3 4", "0 3 4", "0 1 4 6 7",// Box Position Row 5
                                    "0 1 3 6 7","3 4 7", "3 4 6"},
                                    { "2 4 5", "1 4 5", "1 2 5 7 8",//Box Position Row 3
                                    "1 2 4 7 8", "4 5 8", "4 5 7"}};
    //array int use with Make 2 BoxTime.
    int[,] sSelectColumn = { { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }};
    /* All index Make Monster
     0 1 2
     3 4 5
     6 7 8
         */
    
    void Start () {
        //Basec Start Value 
        nRandomPrefab = 0;
        nRandomPosition = 0;
        //Debug.Log(SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().name.Equals("Forest"))
        {
            fValueIf = gameManager.fCheckIF1;
        }
        else if (SceneManager.GetActiveScene().name.Equals("Future"))
        {
            fValueIf = gameManager.fCheckIF2;
        }
        
	}
    
    void Update() {
        //Debug.Log(PlaySong.TimeSong);
        if (DataGame.bPlayGame)
        {
            if (Mathf.Abs(DataGame.fTimeSong - fValueIf[DataGame.nIndexIF]) < 0.075) // if TimeSong maybe ChecIF[IndexIF] -> Time Make Monster in Song
            {
                DataGame.nIndexIF += 1;

                if (Random.Range(1, 3) == 1 || DataGame.nTotalSelect >= 7) // Make 1 Monster in 1 Second.
                {
                    MakeMonster(-1);
                }
                else if (DataGame.nTotalSelect <= 5) //Make 2 Monster in 2 Second.
                {
                    MakeMonster(-1);
                    MakeMonster(nRandomPosition);
                }
                if (DataGame.nIndexIF >= fValueIf.Length - 1)
                {
                    DataGame.nIndexIF = 4;
                    if (SceneManager.GetActiveScene().name.Equals("Future"))
                    {
                        MakeBos.bOverTime = true;
                    }
                }
            }
            else if (DataGame.nIndexIF == 4 && DataGame.nCountMonster == 0)
            {
                DataGame.bPlayGame = false;
                DataGame.sResultGame = "You Win";
            }
        }
        else
        {
            DataGame.nCountMonster = 0;
            DataGame.nIndexIF = 0;
            nRandomPrefab = 0;
            nRandomPosition = 0;
        }
	}

    //==========================================================================================================================================================

    void MakeMonster(int nIndextFrist) { //IndexFrist Use position random for make index 2
        if (DataGame.nIndexIF > 1) //use for random index time liter
        {
            if (fValueIf[DataGame.nIndexIF] - fValueIf[DataGame.nIndexIF-1] <= 0.551f)
            {
                nIndextFrist = nRandomPosition;
            }
        }

        nRandomPrefab = Random.Range(0, gPrefab.Length);
        if (nIndextFrist == -1)
        {
            if (DataGame.nTotalSelect >= 7) //time make monter in time have Box
            {
                int nNumSelect = (DataGame.nTotalSelect - 9) * (-1); // 0=4+5,1=3+5,2=3+4
                nRandomPosition = sSelectColumn[nNumSelect, Random.Range(0, 3)];
            }
            else if (DataGame.nTotalSelect >= 3) //time make monter in time have Box
            {
                int nNumSelect = (Mathf.CeilToInt(DataGame.nTotalSelect / 3f) - 2) * (-1);// ((5/3)-2)*(-1) = 0
                nRandomPosition = sSelectColumn[Random.Range(nNumSelect, nNumSelect + 2), Random.Range(0, 3)];
            }
            else // time make monster 1 in second.
            {
                nRandomPosition = Random.Range(0, gPositionMake.Length);
            }
            
        }
        else {
            if (DataGame.nTotalSelect >= 7)
            {
                int nNumSelect = (DataGame.nTotalSelect - 9) * (-1); // 0=4+5,1=3+5,2=3+4
                nRandomPosition = sSelectColumn[nNumSelect, Random.Range(0, 3)];
            }
            else if (DataGame.nTotalSelect >= 3)
            {
                int nNumSelect = (Mathf.CeilToInt(DataGame.nTotalSelect / 3f) - 2)* (-1);// ((5/3)-2)*(-1) = 0
                Debug.Log("nIndexFristOld:"+nIndextFrist);
                if (nIndextFrist - 4 >= 2)
                {
                    nIndextFrist -= 2 + nNumSelect;
                }
                else if (nIndextFrist - 4 >= -1)
                {
                    nIndextFrist -= 1 + nNumSelect;
                } else
                {
                    nIndextFrist -= nNumSelect;
                }
                Debug.Log("nNumSelect:"+nNumSelect+",nIndextFrist:"+nIndextFrist);
                Debug.Log(sSelectIndexBox1[nNumSelect, nIndextFrist]);
                string[] sTextPosition = sSelectIndexBox1[nNumSelect, nIndextFrist].Split(' ');
                nRandomPosition = int.Parse(sTextPosition[Random.Range(0, sTextPosition.Length)]);
            }
            else
            {
                string[] sTextPosition = sSelectIndex[nIndextFrist].Split(' ');
                nRandomPosition = int.Parse(sTextPosition[Random.Range(0, sTextPosition.Length)]);
            }
            
        }
        GameObject gMonster = Instantiate(gPrefab[nRandomPrefab]);
        vSavePosition = gPositionMake[nRandomPosition].transform.position;
        gMonster.transform.position = new Vector3(vSavePosition.x + fEditPositionX[nRandomPrefab], vSavePosition.y + fEditPositionY[nRandomPrefab], vSavePosition.z);

        DataGame.nCountMonster += 1;
        //Debug.Log(DataGame.nCountMonster + "," + DataGame.fTimeSong);
        //Debug.Log("index if : "+DataGame.nIndexIF+" , Position index : "+nRandomPosition);
    }
    
}
