using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButton : MonoBehaviour {

    //public GameObject gPosition;
    float fTimeAnimation;

    // Use this for initialization
    void Start () {
        fTimeAnimation = 0f;
    }
	
	// Update is called once per frame
	void Update () {
        
        if (fTimeAnimation <= 2f)
        {
            fTimeAnimation += Time.deltaTime;
        }


        if (fTimeAnimation <= 1f)
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = this.gameObject.transform.up * 1;
        }
        else
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = this.gameObject.transform.up * 0;
        }
    }
}
