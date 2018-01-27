using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YZAnimationCurvePosition : MonoBehaviour
{

    public AnimationCurve y, z;
    public float t;
    public float by, bz, ey, ez;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var p = transform.position;
        p.y = Mathf.LerpUnclamped(by, ey, y.Evaluate(t));
        p.z = Mathf.Lerp(bz, ez, z.Evaluate(t));
        transform.position = p;
        t += Time.deltaTime;
    }
}
