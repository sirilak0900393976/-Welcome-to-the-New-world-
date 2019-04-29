using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoxCode : MonoBehaviour {

    //public GameObject gBox;
    GameObject gSwordLeft;
    GameObject gSwordRigth;
    GameObject gHeadPlayer;
    public GameObject gFXScore;
    TextMesh tText;
    //bool HitPlayer;
    bool bCheckScence;
    Vector3 vSavePosition;
    void Start()
    {
        gSwordLeft = GameObject.Find("[CameraRig]/Controller (left)/Cube");
        gSwordRigth = GameObject.Find("[CameraRig]/Controller (right)/Cube");
        gHeadPlayer = GameObject.Find("[CameraRig]/Camera");
        //HitPlayer = false;
        if (!SceneManager.GetActiveScene().name.Equals("How to play game"))
        {
            bCheckScence = false;
        }
        else
        {
            bCheckScence = true;
        }
    }

    //Update is called once per frame
    void Update()
    {
        if (!bCheckScence)
        {
            MoveMain();
        }
        else
        {
            if (FunctionHTP.regame)
            {
                Destroy(this.gameObject);
            }
            MoveSample();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "sword_left" || collision.gameObject.tag == "sword_right" || collision.gameObject.tag == "head_player")
        {
            //Debug.Log(1);
            vSavePosition = gSwordLeft.transform.position;
        }
        else if (collision.gameObject.tag == "sword_right")
        {
            //Debug.Log(2);
            vSavePosition = gSwordRigth.transform.position;
        }
        else if (collision.gameObject.tag == "head_player")
        {
            //Debug.Log(3);
            vSavePosition = gHeadPlayer.transform.position;
        }
        if (!bCheckScence)
        {
            TiggerPlayer(vSavePosition);
        }
        else
        {
            TiggerPlayerSample(vSavePosition);
        }
    }

    void TiggerPlayer(Vector3 vPosition) {
        //HitPlayer = true;
        DataGame.nLife -= 1;
        DataGame.nHit = 0;
        DataGame.bHitFail = true;

        Vector3 vPositionSet = new Vector3( vPosition.x, vPosition.y, vPosition.z + 1.5f);
        GameObject gTextFX = Instantiate(gFXScore, vPositionSet, this.gameObject.transform.rotation);
        gTextFX.transform.rotation = Quaternion.Euler(0, 0, 0);
        tText = gTextFX.GetComponent<TextMesh>();
        tText.text = "Miss";
        tText.color = new Color(199f / 255f, 0f / 255f, 57f / 255f);
        //Debug.Log("Miss Destroy Box");
        Destroy(this.gameObject);
        
    }

    void TiggerPlayerSample(Vector3 vPosition)
    {
        //HitPlayer = true;
        //DataGame.nLife -= 1;
        //DataGame.nHit = 0;
        //DataGame.bHitFail = true;

        Vector3 vPositionSet = new Vector3(vPosition.x, vPosition.y, vPosition.z + 1.5f);
        GameObject gTextFX = Instantiate(gFXScore, vPositionSet, this.gameObject.transform.rotation);
        gTextFX.transform.rotation = Quaternion.Euler(0, 0, 0);
        tText = gTextFX.GetComponent<TextMesh>();
        tText.text = "Miss";
        tText.color = new Color(199f / 255f, 0f / 255f, 57f / 255f);
        //Debug.Log("Miss Destroy Box");
        Destroy(this.gameObject);

    }

    void MoveMain()
    {
        if (DataGame.bPlayGame)
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = this.gameObject.transform.forward * 15;
        }
        if (this.gameObject.transform.position.z <= 68.48f)
        {
            Destroy(this.gameObject);
        }
    }

    void MoveSample()
    {
        if (FunctionHTP.bTime)
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = this.gameObject.transform.forward * 15;
        }
        else
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = this.gameObject.transform.forward * 0;
        }
        if (this.gameObject.transform.position.z < 492.17f-7f)
        {
            Destroy(this.gameObject);
        }
    }
}
