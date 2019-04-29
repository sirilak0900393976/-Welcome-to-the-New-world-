using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster2 : MonoBehaviour {

    public GameObject Position;
    float time;

	// Use this for initialization
	void Start () {
        time = 5f;
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        if (time >= 0f)
        {
            
            Position.GetComponent<Rigidbody>().velocity = Position.transform.forward * 15; //25 
        }
        else
        {
            Debug.Log(time);
            Position.GetComponent<Rigidbody>().velocity = Position.transform.forward * 0; //25 
        }
    }
}
