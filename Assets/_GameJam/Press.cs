using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Press : MonoBehaviour {

    public float expectedLife;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Check(GameObject cube){
        if(cube != null){
            float time = cube.GetComponent<LifeTimer>().life;
            float difference = Mathf.Abs(time - expectedLife);

            if (difference <= 0.5 && difference >= 0)
            {
                Debug.Log("Perfect:" + difference);
                Destroy(cube);
            }
            else if (difference <= 1 && difference > 0.5)
            {
                Debug.Log("OK:" + difference);
                Destroy(cube);
            }
            else
            {
                Debug.Log("Too Far:" + difference);
            }
        }
    }
}
