using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    //get all the sounds of the game serialized
    [SerializeField]
    private AudioClip _MusicAudio;
    [SerializeField]
    private AudioClip _NigthmareMusic;
    [SerializeField]
    private AudioClip _BadObjectAudio;
    [SerializeField]
    private AudioClip _GoodObjectAudio;


    private AudioSource _Music;

    //starts and plays only the music clip on loop
    void Start()
    {
        _Music = GetComponent<AudioSource>();
        _Music.clip = _MusicAudio;
        _Music.loop = true;
        _Music.volume = 0.2f;

        DontDestroyOnLoad(this.gameObject);
        PlayMusic();
    }

    private void PlayMusic()
    {
        _Music.clip = _MusicAudio;
        _Music.Play();
    }
    private void PlayNigthmareMusic()
    {
        _Music.clip = _MusicAudio;
        _Music.Play();
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
