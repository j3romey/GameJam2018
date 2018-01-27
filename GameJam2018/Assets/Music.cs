using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicTimer : MonoBehaviour {

    [SerializeField] KeyCode button;
    AudioSource audio;



    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start () {
        audio.Play();
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(button)){
            Debug.Log(audio.time);
        }	
	}
}
