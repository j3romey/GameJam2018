using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public List<KeyCode> keycodes;

    public SpawnTimes spawnTimes;
    public Press press;

    public AudioSource audio;
    public AnimationCurve soundCurve;
    float soundFloat;

    public AudioClip buttonClip;
    public AudioSource buttonAudio;

    public float timeToHit;

    public string filename;

    public LaneSet laneSet;

    public float space;

    int counter = 0;

    bool paused = true;
    public float gameTimer;

    // Use this for initialization
    public void StartGame()
    {
        paused = false;
        gameTimer = 0;
        soundFloat = 0;
        spawnTimes.Read(filename);
        audio.volume = 1;
        audio.PlayDelayed(timeToHit);

        ScrambleText.instance.totalDrops = spawnTimes.timeList.Count;
        ScrambleText.instance.ReInitialize();
    }

    // Update is called once per frame
    void Update()
    {
        if (!paused)
        {
            gameTimer += Time.deltaTime;


            for (int i = 0; i < keycodes.Count; i++)
            {
                if (Input.GetKeyDown(keycodes[i]))
                {
                    buttonAudio.PlayOneShot(buttonClip);
                    GameObject cube = laneSet.lanes[i].Closest(0f);
                    press.Check(cube);
                }
            }
            //Time.time
            if (counter < spawnTimes.timeList.Count && gameTimer + timeToHit >= spawnTimes.timeList[counter])
            {
                laneSet.lanes[spawnTimes.laneList[counter]].Spawn();
                counter++;
            }


        }else{
            if(soundFloat <= 1.0f){
                soundFloat += Time.deltaTime;
                audio.volume = Mathf.Lerp(1.0f, 0.0f, soundCurve.Evaluate(soundFloat));
            }else{
                audio.Stop();
            }
        }
    }

    public void Stop()
    {
        paused = true;
        counter = 0;
        gameTimer = 0;
    }
}
