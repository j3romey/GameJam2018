using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFollower : MonoBehaviour
{

    public GameObject prefab;
    public GameObject instance;

    // Use this for initialization
    void Start()
    {
        instance = Instantiate(prefab, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        instance.transform.position = transform.position;
    }
}
