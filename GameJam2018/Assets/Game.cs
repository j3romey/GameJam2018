using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    public List<KeyCode> keycodes;

    public float space;

    [System.Serializable]
    public class Lane
    {
        public float dropTime;
        public GameObject dropPrefab;

        public List<GameObject> cubes;

        public Lane()
        {
            cubes = new List<GameObject>();
        }

    }

    public List<Lane> lanes;

    void Awake()
    {
        // lanes = new List<Lane>(keycodes.Count);
        // for (int i = 0; i < lanes.Count; i++) lanes.Add(new Lane());
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // foreach (var v in lanes)
        // {
        //     if (Time.time > v.dropTime)
        //     {
        //         var go = Instantiate(v.dropPrefab, v.initPosition, Quaternion.identity);
        //         v.cubes.Add(go);
        //         v.dropTime = Time.time + Random.Range(2, 6) * 0.25f;
        //     }
        // }
        foreach (var v in lanes) v.cubes.RemoveAll(item => item == null);
        float f = space * -lanes.Count + space;

        for (int i = 0; i < keycodes.Count; i++)
        {
            if (Input.GetKeyDown(keycodes[i]))
            {
                var lane = lanes[i];
                var go = Instantiate(lane.dropPrefab, Vector3.right * f + Vector3.up * 15, Quaternion.identity);
                if (lane.cubes.Count < 0)
                {
                    GameObject min = lane.cubes[0];
                    foreach (var c in lane.cubes)
                    {
                        if (c.transform.position.y >= -1 && c.transform.position.y < min.transform.position.y)
                        {
                            min = c;
                        }
                    }
                    Destroy(min);
                }
            }
            f += 2 * space;
        }
    }
}
