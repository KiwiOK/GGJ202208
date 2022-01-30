using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //get all the sounds of the game serialized
    [SerializeField]
    private AudioClip _MusicAudio;
    [SerializeField]
    private AudioClip _NigthmareMusic;
    [SerializeField]
    private AudioClip _TransitionMusic;
    [SerializeField]
    private AudioClip _EndGameMusic;
    [SerializeField]
    private AudioClip _MenuMusic;
    [SerializeField]
    private AudioClip[] _BatSound;
    [SerializeField]
    private AudioClip _BirdAudio;
    [SerializeField]
    private AudioClip[] _ImpactSound;
    [SerializeField]
    private AudioClip[] _FootStepsSound;
    [SerializeField]
    private AudioClip[] _JumpSound;
    [SerializeField]
    private AudioClip[] _SideWaisSound;
    [SerializeField]
    private AudioClip[] _VanillaThoughtsSound;
    [SerializeField]
    private AudioClip[] _DistortedThoughtsSound;
    [SerializeField]
    private AudioClip[] _TripSound;
    [SerializeField]
    private AudioClip[] _ClickSound;

    private AudioSource _Music;

    //starts and plays only the music clip on loop
    void Start()
    {
        _Music = GetComponent<AudioSource>();
        _Music.clip = _MenuMusic;
        _Music.loop = true;
        _Music.volume = 0.2f;

        DontDestroyOnLoad(this.gameObject);
        PlayMenuMusic();
    }

    public void PlayMusic()
    {
        _Music.clip = _MusicAudio;
        _Music.Play();
    }

    public void PlayNigthmareMusic()
    {
        _Music.clip = _NigthmareMusic;
        _Music.Play();
    }
    public void PlayTransitionMusic()
    {
        _Music.clip = _TransitionMusic;
        _Music.Play();
    }
    public void PlayEndGameMusic()
    {
        _Music.clip = _EndGameMusic;
        _Music.Play();
    }
    public void PlayMenuMusic()
    {
        _Music.clip = _MenuMusic;
        _Music.Play();
    }
    public void PlayBatSound(AudioSource source)
    {
        source.clip = _BatSound[(int)Random.Range(0,8)];
        source.Play();
    }
    public void PlayBirdAudio(AudioSource source)
    {
        source.clip = _BirdAudio;
        source.Play();
    }
    public void PlayImpactSound(AudioSource source)
    {
        source.clip = _ImpactSound[(int)Random.Range(0, 3)];
        source.Play();
    }
    public void PlayFootStepsSound(AudioSource source)
    {
        source.clip = _FootStepsSound[(int)Random.Range(0, 3)];
        source.Play();
    }
    public void PlayJumpSound(AudioSource source)
    {
        source.clip = _JumpSound[(int)Random.Range(0, 3)];
        source.Play();
    }
    public void PlaySideWaisSound(AudioSource source)
    {
        source.clip = _SideWaisSound[(int)Random.Range(0, 2)];
        source.Play();
    }
    public void PlayVanillaThoughtsSound(AudioSource source)
    {
        source.clip = _VanillaThoughtsSound[(int)Random.Range(0, 2)];
        source.Play();
    }
    public void PlayDistortedThoughtsSound(AudioSource source)
    {
        source.clip = _DistortedThoughtsSound[(int)Random.Range(0, 2)];
        source.Play();
    }
    public void PlayTripSound(AudioSource source)
    {
        source.clip = _TripSound[(int)Random.Range(0, 5)];
        source.Play();
    }
    public void PlayClickSound(AudioSource source)
    {
        source.clip = _ClickSound[(int)Random.Range(0, 2)];
        source.Play();
    }
}
