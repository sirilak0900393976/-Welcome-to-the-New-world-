using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBos : MonoBehaviour {

    //set data with unity
    public GameObject gHead;
    public GameObject gBody;
    public GameObject gLastBody;

    GameObject gBos;
    float fPositionZ;
    //position make
    Vector3 vSetPosition;

    //bool check
    bool bMakeHead;
    bool bMakeBody;
    public static bool bOverTime;

	// Use this for initialization
	void Start () {
        bMakeHead = false;
        bOverTime = false;
        bMakeBody = false;
        fPositionZ = 143.47f;
        vSetPosition = new Vector3(85.2f, 0.09f - 4.4f, 150.78f); //position start make head bos
	}
	
	// Update is called once per frame
	void Update () {
        if (DataGame.bPlayGame)
        {
            if (!bMakeHead)
            {
                if (Mathf.Abs(DataGame.fTimeSong - 115.5f) < 0.075)
                {
                    Debug.Log("Make Head");
                    bMakeHead = true;
                    gBos = Instantiate(gHead);
                    gBos.transform.position = vSetPosition;
                    vSetPosition = new Vector3(84.78899f, -1.44f, 150.16f - 0.15f);
                }
            }
            else if (!bOverTime)
            {
                if (gBos.transform.position.z <= fPositionZ)
                {
                    //Debug.Log("Make Head");
                    GameObject gSave = gBos;
                    gBos = Instantiate(gBody);
                    gBos.transform.position = vSetPosition;
                    fPositionZ = 141.92f;
                }
            }
        }
        else {
            bMakeHead = false;
            bOverTime = false;
            bMakeBody = false;
            fPositionZ = 143.47f;
            vSetPosition = new Vector3(85.2f, 0.09f - 4.4f, 150.78f);
        }
	}
}
