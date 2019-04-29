using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHTP : MonoBehaviour {
    bool checkbutton;
    float fTime;
	void Start () {
        //Debug.Log("step"+FunctionHTP.nStep);
        fTime = 1f;
        checkbutton = false;

        if (!this.gameObject.name.Equals("ButtonHome(Clone)") && !this.gameObject.name.Equals("ButtonPlayagain(Clone)") && !this.gameObject.name.Equals("Check")) {
            checkbutton = true;
            FunctionHTP.bContro = true;
            FunctionHTP.bTime = false;
            FunctionHTP.sControSong = "pause";
        }
        
	}
	
	// Update is called once per frame
	void Update () {
        if (FunctionHTP.regame && !this.gameObject.name.Equals("Check") && !this.gameObject.name.Equals("ButtonPlayagain(Clone)"))
        {
            Debug.Log(this.gameObject.name);
            Destroy(this.gameObject);
        }
        if (fTime > 0f)
        {
            if (checkbutton)
            {
                this.gameObject.GetComponent<Rigidbody>().velocity = this.gameObject.transform.forward * -1;
            }
            else
            {
                this.gameObject.GetComponent<Rigidbody>().velocity = this.gameObject.transform.up * -1;
            }
            fTime -= Time.deltaTime; //25
        }
        else
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = this.gameObject.transform.forward * 0;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        FunctionButtonHTP(collision);
    }

    private void OnCollisionStay(Collision collision)
    {
        FunctionButtonHTP(collision);
    }

    void FunctionButtonHTP(Collision collision)
    {
        if (collision.gameObject.tag == "sword_left" ||
            collision.gameObject.tag == "sword_right")
        {
            if (this.gameObject.name.Equals("ButtonHome(Clone)"))
            {

                SceneManager.LoadScene("Home game");

            }
            else if (this.gameObject.name.Equals("ButtonPlayagain(Clone)"))
            {
                FunctionHTP.regame = true;
                FunctionHTP.playgame = false;
                Debug.Log(this.gameObject.name);
                Destroy(this.gameObject);
                //Debug.Log(FunctionHTP.regame);
            } else if (this.gameObject.name.Equals("Check")) {
                FunctionHTP.regame = false;
                FunctionHTP.playgame = false;
                Debug.Log(this.gameObject.name);
                Debug.Log(FunctionHTP.regame + " " + FunctionHTP.playgame);
                Destroy(this.gameObject);
            }
            else
            {
                FunctionHTP.nStep += 1;
                FunctionHTP.bStep = true;
                Debug.Log(this.gameObject.name);
                FunctionHTP.bContro = true;
                FunctionHTP.bTime = true;
                FunctionHTP.sControSong = "play";
                Destroy(this.gameObject);
            }
            
        }
    }
}
