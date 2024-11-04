using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : SingletonBase<SoundManager>
{
    //TODO:Œã‚Å’Ç‰Á
    //public AudioSource BGM;
    public AudioSource BGM;
    public AudioSource GameClear;
    public AudioSource GameOver;
    public AudioSource Click;
    public AudioSource coinGet;
    public AudioSource jump;



    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }



    public void Play(AudioSource playToSound)
    {
        if (!playToSound.isPlaying)
        {
            playToSound.Play();
        }
    }
}
