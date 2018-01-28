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

    //comboCounter
    public int counter;

    public float life;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0)
        {

            if (type == Type.Key)
            {
                if (Miss) Instantiate(Miss, transform.position, transform.rotation);
                keyState = State.Miss;
                TestText.instance.Write(keyState.ToString() + " x_x");
                ScrambleText.instance.Decide(2);
                ComboTracker.instance.counter = 0;
                ComboTracker.instance.Change();
            }

            // send to text
            Destroy(gameObject);
        }
        life -= Time.deltaTime;


    }

    public void Hit(State state)
    {

        if (state == State.Miss)
        {
            ComboTracker.instance.counter = 0;
        }
        else
        {
            ComboTracker.instance.counter++;
        }

        ComboTracker.instance.Change();

        switch (state)
        {
            case State.Perfect:
                if (Perfect) Instantiate(Perfect, transform.position, transform.rotation);
                ScrambleText.instance.Decide(0);
                TestText.instance.Write(state.ToString() + "!! :D");
                break;
            case State.Good:
                if (Good) Instantiate(Good, transform.position, transform.rotation);
                ScrambleText.instance.Decide(1);
                TestText.instance.Write(state.ToString());
                break;
            case State.Ok:
                if (Ok) Instantiate(Ok, transform.position, transform.rotation);
                ScrambleText.instance.Decide(1);
                TestText.instance.Write(state.ToString() + " :)");

                break;
            case State.Miss:
                if (Miss) Instantiate(Miss, transform.position, transform.rotation);
                ScrambleText.instance.Decide(2);
                TestText.instance.Write(state.ToString() + " X_X");

                break;
            default:
                break;
        }
        keyState = state;
        // send to text
        Destroy(gameObject);
    }
}
