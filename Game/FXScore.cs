using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXScore : MonoBehaviour {
    
    float fTime;
    
	// Use this for initialization
	void Start () {
        fTime = 0.5f;
    }

    // Update is called once per frame
    void Update () {
        fTime -= Time.deltaTime;
        if (fTime >= 0.2f)
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = this.gameObject.transform.up * 2;
            //TScore.GetComponent<Rigidbody>().velocity = TScore.transform.forward * 2;
        }
        else if (fTime >= 0f)
        {
            //un use
            //Position = TScore.transform.position;
            this.gameObject.GetComponent<Rigidbody>().velocity = this.gameObject.transform.up * -1;
           //TScore.GetComponent<Rigidbody>().velocity = TScore.transform.forward * (-2);
        }
        else
        {
            Destroy(this.gameObject);
        }
	}
}
