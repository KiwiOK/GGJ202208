using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private GameObject [] floor;

    bool goodSide = true;
    // Start is called before the first frame update
    void Start()
    {
        floor = GameObject.FindGameObjectsWithTag("Floor");
        mainCam = Camera.main;
        canvas = FindObjectOfType<BackgroundSwitch>().gameObject;
        NewRandomLifesLimit();
        playerBad.SetActive(false);
        playerGood.SetActive(true);
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
        floor[1].GetComponent<FloorScroll>().SendMessage("pasotiempo");

    }
    private void ChangePlayer()
    {
        if (goodSide)
        {
            playerGood.transform.position = new Vector3(playerBad.transform.position.x, -playerBad.transform.position.y, -playerBad.transform.position.z);
            playerBad.SetActive(false);
            playerGood.SetActive(true);
            NewRandomLifesLimit();
            playerGood.GetComponent<PlayerController>().Fall();
        }
        else
        {
            playerBad.transform.position = new Vector3(playerGood.transform.position.x, -playerGood.transform.position.y, -playerGood.transform.position.z);
            playerGood.SetActive(false);
            playerBad.SetActive(true);
            playerBad.GetComponent<PlayerController>().Fall();
        }
    }

    private void NewRandomLifesLimit()
    {
        nLimitH = Random.Range(1, 5);
        Debug.Log("VidasAux " + nLimitH);
        playerGood.GetComponent<PlayerController>().SetLifesLimit(nLimitH);
        playerBad.GetComponent<PlayerController>().SetLifesLimit(nLifes - nLimitH, nLimitH);
    }

    public void HandleLifes(bool goodPlayer, int vidas)
    {
        Debug.Log(goodPlayer + ", " + vidas);
        if (goodPlayer && vidas == 0)
            ChangeSide();
        else if (!goodPlayer)
        {
            if (vidas > 0)
                ChangeSide();
            else
                SceneManager.LoadScene("Pajarito", LoadSceneMode.Single);
        }
    }
}
