using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestText : MonoBehaviour {

    public static TestText instance;
    public Text HitStatus;
    public float Delay;
    float Timer;

    private void Awake()
    {
        instance = this;
    }


	// Use this for initialization
	void Start () {
        Timer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        Timer += Time.deltaTime;

        if(Timer > Delay){
            HitStatus.text = "";
        }
	}

    public void Write(string s){
        HitStatus.text = s;
        Timer = 0f;
    }
}
