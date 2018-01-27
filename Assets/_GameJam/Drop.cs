using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{

    public AnimationCurve animationCurve;
    public float t;

    Vector3 start, end;

    //public Vector3 displace;

    // Use this for initialization
    void Start()
    {
        start = transform.position;
        end = transform.position + new Vector3(0, -20, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += displace * Time.deltaTime;
        transform.position = Vector3.Lerp(start, end, animationCurve.Evaluate(t));
        t += Time.deltaTime;
    }
}
