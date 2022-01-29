using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    //get all the sounds of the game serialized
    [SerializeField]
    private AudioClip _MusicAudio;
    [SerializeField]
    private AudioClip _BadObjectAudio;
    [SerializeField]
    private AudioClip _GoodObjectAudio;


    private AudioSource m_Music;

    //starts and plays only the music clip on loop
    void Start()
    {
        m_Music = GetComponent<AudioSource>();
        m_Music.clip = _MusicAudio;
        m_Music.loop = true;
        m_Music.volume = 0.2f;

        DontDestroyOnLoad(this.gameObject);
        PlayMusic();
    }

    private void PlayMusic()
    {
        m_Music.Play();
    }

    public void BadObjectSound(AudioSource source)
    {
        source.clip = _BadObjectAudio;
        source.Play();
    }
    public void GoodObjectSound(AudioSource source)
    {
        source.clip = _GoodObjectAudio;
        source.Play();
    }
}
