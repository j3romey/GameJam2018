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

    public Transform sky;
    public float mainmenuskyrotate, level1skyrotate, level2skyrotate;
    public AnimationCurve skycurve; float skyt; float skyangle, skyd;


    public KeyCode toMainKeycode;

    public void ToGame(int i)
    {
        if (cameraRotationT > 0) return;
        cameraRotationDirection = 1;
        cameraRotationT = 0;
        mainMenu.FlickerOff(.5f);

        if (i == 1)
        {
            LoadLevel1();
        }
        else if (i == 2)
        {
            LoadLevel2();
        }
        else LoadLevel3();

        StartCoroutine(FlickerGame());
    }

    IEnumerator FlickerGame()
    {
        yield return new WaitForSeconds(2.0f);
        gameUI.FlickerOn(0.5f);
    }


    void LoadLevel1()
    {
        skyt = 0; skyd = 1; skyangle = level1skyrotate;
    }

    void LoadLevel2()
    {
        skyt = 0; skyd = 1; skyangle = level2skyrotate;
    }

    void LoadLevel3()
    {

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
        skyt = 2.5f;
        skyd = -1;
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
        sky.rotation = Quaternion.LerpUnclamped(Quaternion.Euler(mainmenuskyrotate, 0, 0), Quaternion.Euler(skyangle, 0, 0), skycurve.Evaluate(skyt));
        skyt += skyd * Time.deltaTime;

        if (Input.GetKeyDown(toMainKeycode))
        {
            ToMainMenu();
        }
    }
}
