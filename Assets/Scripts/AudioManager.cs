
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //References to game objects for audio
    public AudioSource SceneMusic;
    public AudioSource Sword;
    public AudioSource Shield;
    public AudioSource Wind;
    public AudioSource Click;
    public AudioSource CollectCoins;

    public void playSword()
    {
        Sword.Play();
    }

    public void playShield()
    {
        Shield.Play();
    }

    public void playWind()
    {
        Wind.Play();
    }

    public void playMusic()
    {
        SceneMusic.Play();
    }    

    public void UIClick()
    {
        Click.Play();
    }

    public void collectCoins()
    {
        CollectCoins.Play();
    }

}

