using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    private GameObject _soundManagerGO;
    private SoundManager _soundManager;
    private AudioSource _audioSource;

    [SerializeField]
    private int _menuSelector;
    //0 = main menu
    //1 = creditos
    //2 = game over

    void Start()
    {
        _soundManagerGO = GameObject.Find("SoundManager");
        _soundManager = _soundManagerGO.GetComponent<SoundManager>();
        _audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void PlayGame()
    {
        _soundManager.PlayClickSound(_audioSource);
        SceneManager.LoadScene("SceneEnviroment");
        _soundManager.PlayMusic();
    }
    public void Restart()
    {
        SceneManager.LoadScene("SceneEnviroment", LoadSceneMode.Single);
    }

    public void Credits()
    {
        _soundManager.PlayClickSound(_audioSource);
        SceneManager.LoadScene("CreditsScene");
        _soundManager.PlayEndGameMusic();
    }

    public void QuitGame()
    {
        _soundManager.PlayClickSound(_audioSource);
        Application.Quit();
    }

    public void ReturnToMainMenu()
    {
        _soundManager.PlayClickSound(_audioSource);
        SceneManager.LoadScene("GameStart");
        _soundManager.PlayMenuMusic();
    }
}

