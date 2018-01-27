using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Game : MonoBehaviour
{
    public List<KeyCode> keycodes;

    public SpawnTimes spawnTimes;

    public string filename;
    string inputOrder;

    public LaneSet laneSet;

    public float space;

    int counter = 0;

    // Use this for initialization
    void Start()
    {
        inputOrder = "";
        spawnTimes.Read(filename);
    }

    // Update is called once per frame
    void Update()
    {

        if(counter < spawnTimes.timeList.Count && Time.time >= spawnTimes.timeList[counter]){
   
            laneSet.lanes[spawnTimes.laneList[counter]].Spawn();
            counter++;
        }

    }
}
