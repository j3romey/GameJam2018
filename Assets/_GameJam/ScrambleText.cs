using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrambleText : MonoBehaviour
{
    public int totalDrops;
    public int currentDrop;
    public int[] grades;
    public Text text;

    [TextArea(10, 20)]
    public string normal, scrambled;

    public string ans;

    public bool debug;

    int dropsPerChar, longerChars, currentChar;
    int[] scores;
    int[] prefixSum;

    // Use this for initialization
    void Start()
    {
        ans = "";
        currentDrop = 0;
        currentChar = 0;
        text.text = ans;
        dropsPerChar = totalDrops / normal.Length;
        longerChars = totalDrops % normal.Length;
        scores = new int[normal.Length];
        prefixSum = new int[normal.Length];
        for (int i = 0; i < prefixSum.Length; i++) prefixSum[i] = dropsPerChar;
        for (int i = 0; i < longerChars; i++) prefixSum[i]++;
        for (int i = 1; i < prefixSum.Length; i++) prefixSum[i] += prefixSum[i - 1];

    }

    // Update is called once per frame
    void Update()
    {
        if (debug)
        {
            // if (Input.GetKeyDown(KeyCode.O)) Next(true);
            // else if (Input.GetKeyDown(KeyCode.P)) Next(false);
        }
    }

    // public void Next(bool b)
    // {
    //     if (b && counter < normal.Length) ans += normal[counter];
    //     else if (!b && counter < scrambled.Length) ans += scrambled[counter];
    //     counter++;
    //     text.text = ans;
    // }

    public void Decide(int x)
    {
        if (currentChar >= normal.Length) return;
        scores[currentChar] += grades[x];
        currentDrop++;
        if (currentDrop > prefixSum[currentChar])
        {
            currentChar++;
        }
        text.text = ans;
    }
}
