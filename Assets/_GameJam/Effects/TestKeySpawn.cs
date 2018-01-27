using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestKeySpawn : MonoBehaviour
{

    public GameObject prefab;

    public Transform begin, end;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var go = Instantiate(prefab);
            var c = go.GetComponent<YZAnimationCurvePosition>();
            c.by = begin.transform.position.y;
            c.bz = begin.transform.position.z;
            c.ey = end.transform.position.y;
            c.ez = end.transform.position.z;
            go.transform.position += Vector3.right * (Random.Range(-3, 3) + 0.5f) * 10;
        }
    }
}
