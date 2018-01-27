using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrambleText : MonoBehaviour
{
    public Text text;

    [TextArea(10, 20)]
    public string normal, scrambled;

    public string ans;
    public int counter;

    public bool debug;


    // Use this for initialization
    void Start()
    {
        ans = "";
        counter = 0;
        text.text = ans;
    }

    // Update is called once per frame
    void Update()
    {
        if (debug)
        {
            if (Input.GetKeyDown(KeyCode.O)) Next(true);
            else if (Input.GetKeyDown(KeyCode.P)) Next(false);
        }
    }

    public void Next(bool b)
    {
        if (b && counter < normal.Length) ans += normal[counter];
        else if (!b && counter < scrambled.Length) ans += scrambled[counter];
        counter++;
        text.text = ans;
    }
}
