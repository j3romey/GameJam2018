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
            cubes.Add(Instantiate(dropPrefab, location, Quaternion.identity));  
        }

        public void Update()
        {
            cubes.RemoveAll(x => x == null);
        }

        public GameObject Closest(float z){

            if(cubes.Count > 0){
                GameObject currentCube = cubes[0];

                float currentDif = 1000f;

                foreach (var cube in cubes)
                {
                    if (cube.transform.position.z - z > currentDif)
                    {
                        currentCube = cube;
                    }
                }

                return currentCube;
            }else{
                return null;
            }
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
            lanes[i].location = (Vector3.right * f + Vector3.up * height + Vector3.forward * 300);
            f += 2 * space;
        }
    }

    void Update(){
        foreach(var lane in lanes){
            lane.Update();
        }
    }
}
