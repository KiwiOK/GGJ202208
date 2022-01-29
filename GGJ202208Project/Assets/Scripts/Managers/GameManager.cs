using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int nLifes = 7;
    private int nLimitH;
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
        NewRandomLifesLimit();
        obstacleSpawner = FindObjectOfType<RoadObjectsManager>().gameObject;
        enviromentManager = FindObjectOfType<EnviromentSystemManager>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            ChangeSide();
    }
    private void ChangeSide()
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
            NewRandomLifesLimit();
        }
        else
        {
            playerBad.transform.position = new Vector3(playerGood.transform.position.x, -playerGood.transform.position.y, -playerGood.transform.position.z);
            playerGood.SetActive(false);
            playerBad.SetActive(true);
        }
    }

    private void NewRandomLifesLimit() {
        nLimitH = Random.Range(1, 5);
        Debug.Log("VidasAux" + nLimitH);
        playerGood.GetComponent<PlayerController>().SetLifes(nLimitH);
        playerBad.GetComponent<PlayerController>().SetLifes(nLifes - nLimitH);
    }

    public void LifesLost(bool goodPlayer)
    {
        if (goodPlayer)
            ChangeSide();
        else { }
        //EndGame
    }
}