using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCurvePosition : MonoBehaviour
{

    public AnimationCurve animationCurve;
    public float t;

    public Vector3 start, end;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(start, end, animationCurve.Evaluate(t));
        t += Time.deltaTime;
    }
}
