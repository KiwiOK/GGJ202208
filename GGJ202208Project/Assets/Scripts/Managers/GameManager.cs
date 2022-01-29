using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject playerGood;
    [SerializeField]
    private GameObject playerBad;
    private Camera mainCam;
    private GameObject canvas, obstacleSpawner, enviromentManager;

    bool goodSide = true;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
        canvas = FindObjectOfType<BackgroundSwitch>().gameObject;
        Debug.Log(canvas);
        obstacleSpawner = FindObjectOfType<RoadObjectsManager>().gameObject;
        enviromentManager = FindObjectOfType<EnviromentSystemManager>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            ChangeSize();
    }
    private void ChangeSize()
    {
        goodSide = !goodSide;
        canvas.GetComponent<BackgroundSwitch>().ChangeBackground();
        mainCam.GetComponent<CameraMovement>().ChangeScenario();
        obstacleSpawner.GetComponent<RoadObjectsManager>().IsPlatformFlipped = !goodSide;
        enviromentManager.GetComponent<EnviromentSystemManager>().IsPlatformFlipped = !goodSide;
        ChangePlayer();

    }
    private void ChangePlayer()
    {
        if (goodSide)
        {
            playerGood.transform.position = new Vector3(playerBad.transform.position.x, -playerBad.transform.position.y, -playerBad.transform.position.z);
            playerBad.SetActive(false);
            playerGood.SetActive(true);
        }
        else
        {
            playerBad.transform.position = new Vector3(playerGood.transform.position.x, -playerGood.transform.position.y, -playerGood.transform.position.z);
            playerGood.SetActive(false);
            playerBad.SetActive(true);
        }
    }
}
