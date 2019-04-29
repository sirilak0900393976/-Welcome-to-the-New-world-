using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    GameObject gPlayer;
    bool bCheck;
	// Use this for initialization
	void Start () {
        gPlayer = GameObject.Find("/Player").gameObject;
        bCheck = false;
    }

    void Update(){
        if (FunctionHTP.bTime)
        {
            if (this.gameObject.transform.position.z >= gPlayer.transform.position.z)
            {
                this.gameObject.GetComponent<Rigidbody>().velocity = this.gameObject.transform.forward * 15;
            }
            else
            {
                this.gameObject.GetComponent<Rigidbody>().velocity = this.gameObject.transform.forward * 0;
                if (!bCheck)
                {
                    bCheck = true;
                    Debug.Log(FunctionHTP.fTime);
                }
            }
        }
    }
}
