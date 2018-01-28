using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerUI : MonoBehaviour
{

    public float flickerTime;
    public bool visible;
    public float prob;
    public Canvas canvas;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (flickerTime >= Time.time)
        {
            if (Random.Range(0.0f, 1) < prob)
            {
                canvas.enabled = !canvas.enabled;
            }
        }
        else
        {
            canvas.enabled = visible;
        }
    }

    public void FlickerOn(float t)
    {
        flickerTime = Time.time + t;
        visible = true;
    }

    public void FlickerOff(float t)
    {
        flickerTime = Time.time + t;
        visible = false;
    }
}
