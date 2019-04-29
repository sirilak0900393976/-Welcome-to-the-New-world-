using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaySong : MonoBehaviour {

    //Type Song
    public AudioSource asSource;
    public AudioClip acPlay;

    //Use make for new game
    public GameObject gCountDown;

    //Type Check Song for function
    public static bool bStopSong;

    // Use this for initialization
    void Start () {

        // Bassic Value
        asSource.clip = acPlay;
        bStopSong = false;
        
    }
	
	// Update is called once per frame
	void Update () {
        DataGame.fTimeSong += Time.deltaTime;
        if (DataGame.bPlaySong)
        {
            DataGame.bPlaySong = false;
            asSource.Play();
        }
        if (!DataGame.bPlayGame && !bStopSong)
        {
            bStopSong = true;
            asSource.Stop();
        }
        //else if (DataGame.bReGame) {
        //    Debug.Log(SceneManager.GetActiveScene().name);
        //    DataGame.fTimeSong = 0f;
        //    bStopSong = false;
        //    Instantiate(gCountDown);
        //}
    }
}
