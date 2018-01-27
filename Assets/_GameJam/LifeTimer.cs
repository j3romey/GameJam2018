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

    public enum Type
    {
        Key, Effect
    };

    State keyState;
    public Text textTest;
    public Type type;

    public GameObject Perfect;
    public GameObject Good;
    public GameObject Ok;
    public GameObject Miss;

    public float life;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0) { 
            
            if(type == Type.Key){
                if (Miss) Instantiate(Miss, transform.position, transform.rotation);
                keyState = State.Miss;
                TestText.instance.Write(keyState.ToString());
            }
           
            // send to text
            Destroy(gameObject); 
        }
        life -= Time.deltaTime;


    }

    public void Hit(State state){
        
        switch(state){
            case State.Perfect:
                if (Perfect) Instantiate(Perfect, transform.position, transform.rotation);
                break;
            case State.Good:
                if (Good) Instantiate(Good, transform.position, transform.rotation);
                break;
            case State.Ok:
                if (Ok) Instantiate(Ok, transform.position, transform.rotation);
                break;
            case State.Miss:
                if (Miss) Instantiate(Miss, transform.position, transform.rotation);
                break;
            default:
                break;
        }
        keyState = state;
        TestText.instance.Write(keyState.ToString());
        // send to text
        Destroy(gameObject);
    }
}
