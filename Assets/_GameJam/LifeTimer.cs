using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTimer : MonoBehaviour
{
    public GameObject spawnOnDeath;

    public float life;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0) { if (spawnOnDeath) Instantiate(spawnOnDeath, transform.position, transform.rotation); Destroy(gameObject); }
        life -= Time.deltaTime;
    }
}
