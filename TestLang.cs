using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLang : MonoBehaviour
{
    
    bool CheckMake;
    float time;

    private void Start()
    {
        CheckMake = false;
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.transform.position.z >= 143.42)
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = this.gameObject.transform.forward * 15;
            time += Time.deltaTime;
        }
        else
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = this.gameObject.transform.forward * 0;
        }
        if (!CheckMake)
        {
            CheckMake = true;
            Debug.Log("" + time);
        }
    }

}
