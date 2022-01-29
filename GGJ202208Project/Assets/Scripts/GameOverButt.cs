using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButt : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("SceneEnviroment", LoadSceneMode.Single);
    }
    public void Credits() {
       // SceneManager.LoadScene("Credits", LoadSceneMode.Single);
    }
    public void Quit() { Application.Quit(); }
}
