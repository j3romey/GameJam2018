using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShot : MonoBehaviour
{

    public KeyCode keyCode;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyCode))
        {
            ScreenCapture.CaptureScreenshot(Application.persistentDataPath + "/" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png");
            Debug.Log("Saved to " + Application.persistentDataPath + "/" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
        }
    }
}
