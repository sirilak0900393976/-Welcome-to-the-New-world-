using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Monster : MonoBehaviour {

    public GameObject gBoom;
    public GameObject gTScore;
    TextMesh tText;
    Vector3 vSetPosition;
    int nMon;

    int nPositionStart = 0;
    int nIndextIfStart = 0;
    bool nCheckScence = false;
    void Start()
    {
        if (!SceneManager.GetActiveScene().name.Equals("How to play game"))
        {
            nPositionStart = RandomMonster.nRandomPosition;
            nIndextIfStart = DataGame.nIndexIF;
            nMon = 1;
            //Debug.Log(DataGame.nCountMonster);
        }
        else
        {
            nCheckScence = true;
            nPositionStart = RandomSample.nPositionMonster;
            nIndextIfStart = RandomSample.nIndex;
            nMon = 1;
        }
        
    }

    // Update is called once per frame
    void Update () {
        if (!nCheckScence)
        {
            MoveMonsterMain();
        }
        else
        {
            if (FunctionHTP.regame) {
                Destroy(this.gameObject);
            }
            MoveMonsterSample();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "sword_left" ||
            collision.gameObject.tag == "sword_right")
        {
            if (!nCheckScence)
            {
                TrigerMonsterMain();
            }
            else
            {
                TrigerMonsterSample();
            }
        }
        else if (collision.gameObject.tag == "head_player")
        {
            Destroy(this.GetComponent<BoxCollider>());
        }
        else
        {
            Debug.Log("name triger : " + collision.gameObject.name + "\n" + "index if : " + nIndextIfStart + "\n" + "index make : " + nPositionStart);
            if (!nCheckScence)
            {
                DataGame.nCountMonster -= nMon;
            }
            else
            {
                FunctionHTP.nCountMonster -= nMon;
            }
            nMon = 0;
            Destroy(this.gameObject);
        }



    }

    void MoveMonsterMain()
    {
        if (DataGame.bPlayGame)
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = this.gameObject.transform.forward * 15; //25
        }
        else
        {
            DataGame.nCountMonster -= nMon;
            nMon = 0;
            //Debug.Log(DataGame.nCountMonster + "," + DataGame.fTimeSong);
            Destroy(this.gameObject);
        }
        if (this.gameObject.transform.position.z < 72.8)
        {
            DataGame.nLife -= 1;
            DataGame.nHit = 0;
            DataGame.bHitFail = true;
            Vector3 vPositionSet = new Vector3(252.6f, 0.165f, 81.94f);
            GameObject gTextFX = Instantiate(gTScore, vPositionSet, this.gameObject.transform.rotation);
            gTextFX.transform.rotation = Quaternion.Euler(0, 0, 0);
            tText = gTextFX.GetComponent<TextMesh>();
            tText.text = "Miss";
            tText.color = new Color(199f / 255f, 0f / 255f, 57f / 255f);
            DataGame.nCountMonster -= nMon;
            nMon = 0;
            //Debug.Log(DataGame.nCountMonster + "," + DataGame.fTimeSong);
            Destroy(this.gameObject);
        }
    }

    void MoveMonsterSample()
    {
        if (FunctionHTP.bTime)
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = this.gameObject.transform.forward * 7; //25
        }
        else
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = this.gameObject.transform.forward * 0;
        }
        if (this.gameObject.transform.position.z < 492.17-3)
        {
            Vector3 vPositionSet = new Vector3(252.6f, 0.165f, 81.94f);
            GameObject gTextFX = Instantiate(gTScore, vPositionSet, this.gameObject.transform.rotation);
            gTextFX.transform.rotation = Quaternion.Euler(0, 0, 0);
            tText = gTextFX.GetComponent<TextMesh>();
            tText.text = "Miss";
            tText.color = new Color(199f / 255f, 0f / 255f, 57f / 255f);
            FunctionHTP.nCountMonster -= nMon;
            nMon = 0;
            Destroy(this.gameObject);
        }
    }


    void TrigerMonsterMain()
    {
        DataGame.nHit += 1;
        DataGame.bHit = true;
        Instantiate(gBoom, this.gameObject.transform.position, this.gameObject.transform.rotation);
        vSetPosition = this.gameObject.transform.position;
        vSetPosition = new Vector3(vSetPosition.x, vSetPosition.y, vSetPosition.z + 1.5f);
        GameObject gTextFX = Instantiate(gTScore, vSetPosition, this.gameObject.transform.rotation);
        gTextFX.transform.rotation = Quaternion.Euler(0, 0, 0);
        if (DataGame.nCombo >= 8)
        {
            DataGame.nCombo = 8;
        }
        tText = gTextFX.GetComponent<TextMesh>();
        tText.text = "" + (10 + 10 * DataGame.nCombo);
        tText.color = new Color(46f / 255f, 204f / 255f, 113f / 255f);
        DataGame.nCountMonster -= nMon;
        nMon = 0;
        //Debug.Log(DataGame.nCountMonster + "," + DataGame.fTimeSong);
        Destroy(this.gameObject);
    }

    void TrigerMonsterSample()
    {
        Instantiate(gBoom, this.gameObject.transform.position, this.gameObject.transform.rotation);
        vSetPosition = this.gameObject.transform.position;
        vSetPosition = new Vector3(vSetPosition.x, vSetPosition.y, vSetPosition.z + 1.5f);
        GameObject gTextFX = Instantiate(gTScore, vSetPosition, this.gameObject.transform.rotation);
        gTextFX.transform.rotation = Quaternion.Euler(0, 0, 0);
        tText = gTextFX.GetComponent<TextMesh>();
        tText.color = new Color(46f / 255f, 204f / 255f, 113f / 255f);
        FunctionHTP.nCountMonster -= nMon;
        nMon = 0;
        Destroy(this.gameObject);
    }

}
