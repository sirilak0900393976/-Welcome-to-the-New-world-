using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBos : MonoBehaviour {

    bool bHead;
    bool bAnime;
    Animator aAnimator;

	// Use this for initialization
	void Start () {
        bAnime = false;
        if (this.gameObject.name.Equals("Boss(Clone)"))
        {
            bHead = true;
            aAnimator = this.gameObject.GetComponent<Animator>();
        }
        else
        {
            bAnime = true;
            bHead = false;
        }

	}
	
	// Update is called once per frame
	void Update () {
        if (bHead)
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = this.gameObject.transform.forward * 15;
        }
        else
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = this.gameObject.transform.up * -15;
        }

        if (this.gameObject.transform.position.z <= 117.08f && !bAnime)
        {
            bAnime = true;
            aAnimator.SetTrigger("Hit");
        }

        if (this.gameObject.transform.position.z <= 78f)
        {
            Destroy(this.gameObject);
        }
    }
}
