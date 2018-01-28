using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScore : MonoBehaviour {

    public Text perfect, ok , miss;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        perfect.text = "Perfect: " + ComboTracker.instance.perfect;
        ok.text = "OK: " + ComboTracker.instance.ok;
        miss.text = "Miss: " + ComboTracker.instance.miss;
	}
}
