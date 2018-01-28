using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSelection : MonoBehaviour
{

    public Transform cameraTransform;
    public float menuCameraAngle;

    public AnimationCurve cameraRotationCurve;
    public float cameraRotationDirection;
    float cameraRotationT;

    Quaternion defaultCameraRotation;

    public FlickerUI mainMenu, gameUI;

    public LaneSet laneSet;
    public Game game;
    public AudioSource gameSong;


    public KeyCode toMainKeycode;

    public void ToGame()
    {
        if (cameraRotationT > 0) return;
        cameraRotationDirection = 1;
        cameraRotationT = 0;
        mainMenu.FlickerOff(.5f);
        StartCoroutine(FlickerGame());
    }

    IEnumerator FlickerGame()
    {
        yield return new WaitForSeconds(2.0f);
        gameUI.FlickerOn(0.5f);
    }

    public void ToMainMenu()
    {
        if (cameraRotationT < 2.5f) return;
        cameraRotationDirection = -1;
        cameraRotationT = 2.5f;
        gameUI.FlickerOff(0.5f);
        laneSet.DestroyLanes();
        game.Stop();
        StartCoroutine(FlickerMainMenu());
    }

    IEnumerator FlickerMainMenu()
    {
        yield return new WaitForSeconds(2.0f);
        mainMenu.FlickerOn(0.5f);
    }

    // Use this for initialization
    void Start()
    {
        defaultCameraRotation = Quaternion.Euler(menuCameraAngle, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        cameraTransform.rotation = Quaternion.Lerp(defaultCameraRotation, Quaternion.identity, cameraRotationCurve.Evaluate(cameraRotationT));
        cameraRotationT += cameraRotationDirection * Time.deltaTime;

        if (Input.GetKeyDown(toMainKeycode))
        {
            ToMainMenu();
        }
    }
}
