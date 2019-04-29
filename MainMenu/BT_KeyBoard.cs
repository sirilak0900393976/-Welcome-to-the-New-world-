using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BT_KeyBoard : MonoBehaviour {

    float fTime = 0f;
    bool bColor = false;
    public Material[] mRemove = new Material[3];
    
    void Update()
    {
        if (fTime > 0)
        {
            fTime -= Time.deltaTime;
        }
        else if (fTime <= 0 && !bColor)
        {
            bColor = true;
            if (this.gameObject.name.Equals("Remove"))
            {
                this.GetComponent<Renderer>().material = mRemove[0];
            }
            else if (this.gameObject.name.Length == 1)
            {
                this.GetComponent<Renderer>().material = DataMenu.mKeyBoard[0];
            }
            else
            {
                this.GetComponent<Renderer>().material = DataMenu.mMain[0];
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        FunctionBT_KeyBoard(other);
    }

    private void OnTriggerStay(Collider other)
    {
        FunctionBT_KeyBoard(other);
    }

    private void OnTriggerExit(Collider other)
    {
        bColor = false;
    }


    //================================================================================================


    void FunctionBT_KeyBoard(Collider other)
    {
        if (DataMenu.CheckTriger(other) && fTime <= 0f)
        {
            //Debug.Log(this.gameObject.name);
            fTime = 0.3f;
            

            if (this.gameObject.name.Length == 1)
            {
                this.GetComponent<Renderer>().material = DataMenu.mKeyBoard[2];
                //Debug.Log("Use SelectChar()");
                SelectChar();
            }
            else if (this.gameObject.name.Equals("Remove"))
            {
                this.GetComponent<Renderer>().material = mRemove[2];
                //Debug.Log("Use RemoveChar()");
                RemoveChar();
            }
            else if (this.gameObject.name.Equals("Select"))
            {
                this.GetComponent<Renderer>().material = DataMenu.mMain[2];
                //Debug.Log("Use SelectName()");
                SelectName();
            }
            else if (this.gameObject.name.Equals("Exit"))
            {
                this.GetComponent<Renderer>().material = DataMenu.mMain[2];
                //Debug.Log("Use ExitKeyBoard()");
                ExitKeyBoard();
            }
        }
        else
        {
            if (this.gameObject.name.Equals("Remove"))
            {
                this.GetComponent<Renderer>().material = mRemove[1];
            }
            else if (this.gameObject.name.Length == 1)
            {
                this.GetComponent<Renderer>().material = DataMenu.mKeyBoard[1];
            }
            else
            {
                this.GetComponent<Renderer>().material = DataMenu.mMain[1];
            }
        }
    }


    void SelectChar()
    {
        
        if (DataMenu.tMakeName.text.Length <= 12)
        {
            DataMenu.tMakeName.text += this.gameObject.name;
        }
    }

    void RemoveChar()
    {
        if (DataMenu.tMakeName.text.Length > 0)
        {
            DataMenu.tMakeName.text = DataMenu.tMakeName.text.Remove(DataMenu.tMakeName.text.Length - 1, 1);
        }
    }

    void SelectName()
    {
        DataMenu.bCreateName = false;
        DataMenu.gSelectEdit.GetComponent<Renderer>().material = DataMenu.mMain[0];
        DataMenu.tName.text = DataMenu.tMakeName.text;
        Destroy(DataMenu.gKeyBoard.gameObject);
    }

    void ExitKeyBoard()
    {
        DataMenu.bCreateName = false;
        DataMenu.gSelectEdit.GetComponent<Renderer>().material = DataMenu.mMain[0];
        Destroy(DataMenu.gKeyBoard.gameObject);
    }
}
