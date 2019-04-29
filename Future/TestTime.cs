using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTime : MonoBehaviour {
    //0.02912959 0.01312989 0.02933314
    public GameObject Position;
    public GameObject Monster;
    GameObject TestMonster;

	// Use this for initialization
	void Start () {
        TestMonster = Instantiate(Monster);
        TestMonster.transform.position = Position.transform.position;
	}

}
