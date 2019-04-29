using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class MainMenuLeftHand : MonoBehaviour {

    public SteamVR_Action_Boolean interactWithUI = SteamVR_Input.GetBooleanAction("InteractUI");
    public SteamVR_Behaviour_Pose pose;
    
    void Start () {
        if (pose == null)
            pose = this.GetComponent<SteamVR_Behaviour_Pose>();
        if (pose == null)
            Debug.LogError("No SteamVR_Behaviour_Pose component found on this object");
        if (interactWithUI == null)
            Debug.LogError("No ui interaction action has been set on this component.");
    }
	
	// Update is called once per frame
	void Update () {
        if (interactWithUI != null && interactWithUI.GetState(pose.inputSource)){
            DataMenu.bLeftHand = true;
        }else{
            DataMenu.bLeftHand = false;
        }
    }
}
