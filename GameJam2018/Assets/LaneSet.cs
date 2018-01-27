using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneSet : MonoBehaviour {

    public List<Lane> lanes;
    public int dropSpeed;
    public float space;
    float curSpace;
    public float height;

    [System.Serializable]
    public class Lane
    {
        public GameObject dropPrefab;

        public List<GameObject> cubes;

        public Vector3 location;

        public Lane()
        {
            cubes = new List<GameObject>();
        }

        public void Spawn(){
            Instantiate(dropPrefab, location, Quaternion.identity);   
        }
    }

    void Awake()
    {
        curSpace = space * -lanes.Count + space;
    }

    // Use this for initialization
    void Start () {

        float f = space * -lanes.Count + space;

        for (int i = 0; i < lanes.Count; i++){
            lanes[i].location = (Vector3.right * f + Vector3.up * height);
            f += 2 * space;
        }


	}
}
