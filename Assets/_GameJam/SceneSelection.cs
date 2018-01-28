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

    public FlickerUI amazingCanvas;

    public RectTransform scrambletransform;
    public ScrambleText scrambleText;
    public float scrambley, amazingscrambly;

    public string name1, name2, name3;
    public AudioClip clip1, clip2, clip3;

    [TextArea(10, 20)]
    public string text1, text2, text3;

    public float p1, p2, p3;

    public GameObject endScore;

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



        laneSet.CalcLane();
        game.StartGame();

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
        scrambletransform.anchoredPosition = Vector2.up * scrambley;
        scrambleText.normal = text1;
        laneSet.height = 0;
        game.filename = name1;
        gameSong.clip = clip1;
        game.spawnTimes.period = p1;
        laneSet.SelectCurve(0);
    }

    void LoadLevel2()
    {
        skyt = 0; skyd = 1; skyangle = level2skyrotate;
        scrambletransform.anchoredPosition = Vector2.up * scrambley;
        scrambleText.normal = text2;
        laneSet.height = 0;
        game.filename = name2;
        gameSong.clip = clip2;
        game.spawnTimes.period = p2;
        laneSet.SelectCurve(0);
    }

    void LoadLevel3()
    {
        laneSet.height = 70;
        game.filename = name3;
        scrambleText.normal = text3;
        laneSet.SelectCurve(1);
        gameSong.clip = clip3;
        skyt = 0; skyd = 0; skyangle = mainmenuskyrotate;
        scrambletransform.anchoredPosition = Vector2.up * amazingscrambly;
        game.spawnTimes.period = p3;
        StartCoroutine(FlickerAmazing());
    }

    IEnumerator FlickerAmazing()
    {
        yield return new WaitForSeconds(5.5f);
        if (cameraRotationT >= 2.5f)
            amazingCanvas.FlickerOn(0.5f);
    }

    public void ToMainMenu()
    {
        endScore.SetActive(true);
        if (cameraRotationT < 2.5f) return;
        cameraRotationDirection = -1;
        cameraRotationT = 2.5f;
        gameUI.FlickerOff(0.5f);
        laneSet.DestroyLanes();
        game.Stop();
        StartCoroutine(FlickerMainMenu());
        skyt = 2.5f;
        skyd = -1;

        ComboTracker.instance.perfect = 0;
        ComboTracker.instance.miss = 0;
        ComboTracker.instance.ok = 0;

        if (amazingCanvas.visible) { amazingCanvas.FlickerOff(0.5f); }
        else { amazingCanvas.FlickerOff(0.0f); }
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

        if(game.spawnTimes.timeList.Count > 0){
            if (game.gameTimer >= game.spawnTimes.timeList[game.spawnTimes.timeList.Count - 1])
            {
                endScore.SetActive(true);
            }
        }


    }

    public void Exit()
    {
        Application.Quit();
    }
}
