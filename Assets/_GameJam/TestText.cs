using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestText : MonoBehaviour {

    public static TestText instance;
    public Text HitStatus;


    private void Awake()
    {
        instance = this;
    }


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Write(string s){
        HitStatus.text = s;
    }
}
