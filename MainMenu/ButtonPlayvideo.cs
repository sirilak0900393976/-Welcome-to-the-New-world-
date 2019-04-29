using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlayvideo : MonoBehaviour {


    //public Material mSelect;
    //public Material mButton;
    //public GameObject ButtonPlayvideo;


    public AudioClip movieAudioClip;
    public MovieTexture movieTexture;

    private void OnTriggerEnter(Collider other)
    {
        if (DataMenu.bLeftHand || DataMenu.bRightHand)
        {
           

        }

        Debug.Log("Not Play Video");

    }

    public UnityEngine.Video.VideoClip videoClip;

    void Start()
    {
        var videoPlayer = gameObject.AddComponent<UnityEngine.Video.VideoPlayer>();
        var audioSource = gameObject.AddComponent<AudioSource>();

        videoPlayer.playOnAwake = false;
        videoPlayer.clip = videoClip;
        videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.MaterialOverride;
        videoPlayer.targetMaterialRenderer = GetComponent<Renderer>();
        videoPlayer.targetMaterialProperty = "_MainTex";
        videoPlayer.audioOutputMode = UnityEngine.Video.VideoAudioOutputMode.AudioSource;
        videoPlayer.SetTargetAudioSource(0, audioSource);
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            var vp = GetComponent<UnityEngine.Video.VideoPlayer>();

            if (vp.isPlaying)
            {
                vp.Pause();
            }
            else
            {
                vp.Play();
            }
        }
    }
}