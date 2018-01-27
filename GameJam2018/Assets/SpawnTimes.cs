using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SpawnTimes : MonoBehaviour {

    public bool DEBUG;
    public List<int> laneList;
    public List<float> timeList;

    int counter;
    string inputOrder;


    void Awake()
    {
        counter = 0;
        inputOrder = "";
    }

	void Start () {
 
	}

    public void Read(string filename){
        laneList = new List<int>();
        timeList = new List<float>();

        using (TextReader reader = File.OpenText("Assets/" + filename + ".txt"))
        {
            string[] input;
            string cur;
            while ((cur = reader.ReadLine()) != null)
            {

                if (cur == "") break;

                input = cur.Split(' ');
                laneList.Add(int.Parse(input[0]));
                timeList.Add(float.Parse(input[1]));
            }
        }
    }

    public void Write(int lane, float time){
        Debug.Log(lane + " " + time);
        inputOrder += lane + " " + time + "\n";
    }

    public void FinishWrite(string filename){
        Debug.Log("Written");
        string path = "Assets/" + filename + ".txt";
        StreamWriter writer = new StreamWriter(path, false);
        writer.WriteLine(inputOrder);
        writer.Close();
    }

	// Update is called once per frame
    void Update () {
        if(counter < timeList.Count && Time.time >= timeList[counter] && DEBUG){
            Debug.Log(laneList[counter]);
            counter++;
        }
    }


}
