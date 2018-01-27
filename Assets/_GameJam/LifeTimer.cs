using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeTimer : MonoBehaviour
{
    public enum State
    {
        Perfect, Good, Ok, Miss
    };

    State keyState;
    public Text textTest;

    public GameObject spawnOnDeath;
    public GameObject spawnOnHit;

    public float life;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0) { 
            if (spawnOnDeath) Instantiate(spawnOnDeath, transform.position, transform.rotation);
            keyState = State.Miss;
            TestText.instance.Write(keyState.ToString());
            // send to text
            Destroy(gameObject); 
        }
        life -= Time.deltaTime;


    }

    public void Hit(State state){
        if (spawnOnHit) Instantiate(spawnOnDeath, transform.position, transform.rotation);
        keyState = state;
        TestText.instance.Write(keyState.ToString());
        // send to text
        Destroy(gameObject);
    }
}
