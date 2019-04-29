using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBox : MonoBehaviour {
    
    //Input with Unity
    public GameObject gBox;
    public GameObject[] gPositionMake;
    public float fSetX;
    public float fSetY;
    public float fSetZ;
    float fBoxTimeStart;
    float fBoxTimeEnd;
    Vector3 vSavePosition;
    float fTimeBox;
    int nSecondSelect;
    
    void Start () {
        nSecondSelect = 0;
        fTimeBox = -5f;
        fBoxTimeStart = 23f;
        fBoxTimeEnd = 35f;
    }
	
	void Update () {
        if (DataGame.bPlayGame)
        {
            if (DataGame.fTimeSong >= fBoxTimeStart && DataGame.fTimeSong <= fBoxTimeEnd) // If TimeSong in Time Make Box
            {
                if (fTimeBox <= -1.523f)
                {
                    DataGame.nTotalSelect = 0;
                    MakeBox();
                    fTimeBox = 1.523f;
                }
                if (fTimeBox <= 0)
                {
                    DataGame.nTotalSelect = 0;
                }
                fTimeBox -= Time.deltaTime;
            }
            else if (DataGame.fTimeSong >= fBoxTimeEnd)
            {
                fBoxTimeStart = 71f;
                fBoxTimeEnd = 95f;
                DataGame.nTotalSelect = 0;
                fTimeBox = -5f;
            }
        }
        else
        {
            nSecondSelect = 0;
            fTimeBox = -5f;
            fBoxTimeStart = 23f;
            fBoxTimeEnd = 35f;
        }
        
    }


    //==========================================================================================================================================================
    void MakeBox()
    {
        if (Random.Range(0, 5) != 2) //Make 1 Box
        {
            GameObject gSetBox = Instantiate(gBox);
            if (Random.Range(0, 2) == 0) // Select Position Box index 3 or 5 ,this if select index 3.
            {
                DataGame.nTotalSelect = 3;
            }
            else //select index 5
            {
                DataGame.nTotalSelect = 5;
            }
            vSavePosition = gPositionMake[DataGame.nTotalSelect].transform.position;
            gSetBox.transform.position = new Vector3(vSavePosition.x + fSetX, vSavePosition.y + fSetY, vSavePosition.z + fSetZ);
            //Debug.Log("" + DataGame.nIndexIF + " ,Index Box = " + DataGame.nTotalSelect);
        }
        else //Make 2 Box
        {
            DataGame.nTotalSelect = Random.Range(3, 6);
            do
            {
                nSecondSelect = Random.Range(3, 6);
            } while (nSecondSelect == DataGame.nTotalSelect);
            GameObject gSetBox = Instantiate(gBox);
            vSavePosition = gPositionMake[DataGame.nTotalSelect].transform.position;
            gSetBox.transform.position = new Vector3(vSavePosition.x + fSetX, vSavePosition.y + fSetY, 151.97f);
            GameObject gSetBox2 = Instantiate(gBox);
            //Debug.Log("" + DataGame.nIndexIF + " ,Index Box = " + DataGame.nTotalSelect);
            vSavePosition = gPositionMake[nSecondSelect].transform.position;
            gSetBox2.transform.position = new Vector3(vSavePosition.x + fSetX, vSavePosition.y + fSetY, 151.97f);
            //Debug.Log("" + DataGame.nIndexIF + " ,Index Box = " + nSecondSelect);
            DataGame.nTotalSelect += nSecondSelect;
        }
    }
}
