using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Game : MonoBehaviour
{
    public List<KeyCode> keycodes;

    public SpawnTimes spawnTimes;
    public Press press;

    public AudioSource audio;

    public float timeToHit;

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
        audio.PlayDelayed(timeToHit);

        ScrambleText.instance.totalDrops = spawnTimes.timeList.Count;
        ScrambleText.instance.ReInitialize();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < keycodes.Count; i++)
        {
            if (Input.GetKeyDown(keycodes[i]))
            {
                GameObject cube = laneSet.lanes[i].Closest(0f);
                press.Check(cube);
            }
        }


        if (counter < spawnTimes.timeList.Count && Time.time + timeToHit >= spawnTimes.timeList[counter])
        {
            laneSet.lanes[spawnTimes.laneList[counter]].Spawn();
            counter++;
        }
    }
}
