using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create : MonoBehaviour
{
    public List<KeyCode> keycodes;

    public AudioSource audio;

    public string filename;
    public SpawnTimes spawnTimes;

    public LaneSet laneSet;
    public float TimeStart;

    public float space;

    public float Timer;

    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void StartTimer()
    {
        Timer = 0;
        audio.PlayDelayed(TimeStart);
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        //Debug.Log(Timer);

        for (int i = 0; i < keycodes.Count; i++)
        {
            if (Input.GetKeyDown(keycodes[i]))
            {
                spawnTimes.Write(i, Timer);
            }
        }



        if (Input.GetKeyDown(KeyCode.Space))
        {
            spawnTimes.FinishWrite(filename);

        }
    }
}
