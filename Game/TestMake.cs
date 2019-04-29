using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMake : MonoBehaviour {

    public GameObject TestText;
    public GameObject MyPosition;
    float TimeMakeTest;

	// Use this for initialization
	void Start () {
        TimeMakeTest = 0f;

	}
	
	// Update is called once per frame
	void Update () {
        if (TimeMakeTest <= 0f)
        {
            GameObject TestObject = Instantiate(TestText);
            TestObject.transform.position = MyPosition.transform.position;
            TimeMakeTest = 2f;
        }
        TimeMakeTest -= Time.deltaTime;
        
	}
}
