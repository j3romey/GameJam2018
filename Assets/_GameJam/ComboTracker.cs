using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboTracker : MonoBehaviour {

    public static ComboTracker instance;

    public Text counterText;
    public Text wordText;

    public int counter;

    public int perfect, ok, miss;

    void Awake()
    {
        instance = this;
        counter = 0;
        perfect = ok = miss = 0;
    }

    // Use this for initialization
    void Start () {
        counter = 0;
	}
	
	// Update is called once per frame
	public void Change () {
        if(counter > 1){
            counterText.text = counter.ToString();
            wordText.text = "Combo";
        }else{
            counterText.text = "";
            wordText.text = "";
        }
	}

}
