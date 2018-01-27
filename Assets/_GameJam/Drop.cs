using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{

    public AnimationCurve animationCurveY;
    public AnimationCurve animationCurveZ;
    public float t ;

    float yPosition, zPosition;

    public float zStart, zEnd, yStart, yEnd;

    //public Vector3 displace;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        yPosition = Mathf.LerpUnclamped(yStart, yEnd, animationCurveY.Evaluate(t));
        zPosition = Mathf.LerpUnclamped(zStart, zEnd, animationCurveZ.Evaluate(t));
        transform.position = new Vector3(transform.position.x, yPosition, zPosition);
        t += Time.deltaTime;
    }
}
