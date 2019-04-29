using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BoxColor : MonoBehaviour {

    //public GameObject gPosition;
    bool bCheckScence;
    void Start()
    {
        if (!SceneManager.GetActiveScene().name.Equals("How to play game"))
        {
            bCheckScence = false;    
        }
        else
        {
            bCheckScence = true;
        }
    }
    // Update is called once per frame
    void Update () {
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

    void MoveMain()
    {
        if (DataGame.bPlayGame)
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = this.gameObject.transform.forward * 15; //25
        }
        else
        {
            Destroy(this.gameObject);
        }
        //box < 
        if (this.gameObject.transform.position.z <= 68.48f)
        {
            Destroy(this.gameObject);
        }
    }

    void MoveSample()
    {
        if (FunctionHTP.bTime)
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = this.gameObject.transform.forward * 15; //25
        }
        else
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = this.gameObject.transform.forward * 0;
        }
        //box < 
        if (this.gameObject.transform.position.z < 492.17f-7f)
        {
            Destroy(this.gameObject);
        }
    }
}
