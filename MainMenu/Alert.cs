using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alert : MonoBehaviour {
    float fTime;
	// Use this for initialization
	void Start () {
        fTime = 1f;
	}
	
	// Update is called once per frame
	void Update () {
        if (fTime < 0)
        {
            DataMenu.bMakeAlert = false;
            Destroy(this.gameObject);
        }
        fTime -= Time.deltaTime;

	}
}
