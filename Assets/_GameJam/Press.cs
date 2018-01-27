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
            LifeTimer lifeTime = cube.GetComponent<LifeTimer>();
            float difference = Mathf.Abs(lifeTime.life - expectedLife);

            

            if (difference <= 0.15 && difference >= 0)
            {
                Debug.Log("Perfect: " + difference);
             
                lifeTime.Hit(LifeTimer.State.Perfect);

            }
            else if (difference <= 0.3 && difference > 0.15 )
            {
                Debug.Log("OK:" + difference);
                lifeTime.Hit(LifeTimer.State.Ok);
            }else if(difference >= 0.75){
                Debug.Log("Too Far: " + difference);
            }else{
                Debug.Log("Miss: " + difference);
                lifeTime.Hit(LifeTimer.State.Miss);
            }
        }
    }
}
