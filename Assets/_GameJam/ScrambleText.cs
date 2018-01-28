using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ScrambleText : MonoBehaviour
{
    public static ScrambleText instance;

    public int totalDrops;
    public int currentDrop;
    public int[] grades;
    public Text text;

    [TextArea(10, 20)]
    public string normal, scrambled;

    public StringBuilder ans;

    public bool debug;

    int dropsPerChar, longerChars, currentChar;
    int[] scores;
    int[] prefixSum;

    void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start()
    {
        ReInitialize();
    }

    public void ReInitialize()
    {
        currentDrop = 0;
        currentChar = 0;
        dropsPerChar = totalDrops / normal.Length;
        longerChars = totalDrops % normal.Length;
        scores = new int[normal.Length];
        prefixSum = new int[normal.Length];
        for (int i = 0; i < prefixSum.Length; i++) prefixSum[i] = dropsPerChar;
        for (int i = 0; i < longerChars; i++) prefixSum[i]++;
        for (int i = 1; i < prefixSum.Length; i++) prefixSum[i] += prefixSum[i - 1];
        ans = new StringBuilder();
        for (int i = 0; i < normal.Length; i++)
        {
            if (char.IsLetter(normal[i]))
            {
                ans.Append((char)Random.Range((int)'a', (int)'z'));
            }
            else
            {
                ans.Append(normal[i]);
            }
        }
        text.text = ans.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (debug)
        {
            // if (Input.GetKeyDown(KeyCode.O)) Next(true);
            // else if (Input.GetKeyDown(KeyCode.P)) Next(false);
            if (Input.GetKeyDown(KeyCode.I))
            {
                Decide(0);
            }
            if (Input.GetKeyDown(KeyCode.O))
            {
                Decide(1);
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                Decide(2);
            }
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
        if (char.IsLetter(normal[currentChar]))
        {
            if (scores[currentChar] >= dropsPerChar)
            {
                ans[currentChar] = normal[currentChar];
            }
            else
            {
                ans[currentChar] = (char)Random.Range((int)'a', (int)'z');
            }
        }
        currentDrop++;
        if (currentDrop > prefixSum[currentChar])
        {

            currentChar++;
        }
        text.text = ans.ToString();
    }
}
