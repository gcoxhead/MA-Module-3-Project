 
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
    public AudioSource Shop;

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
        Shop.Stop();
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

    public void playShop()
    {
        Shop.Play();
        SceneMusic.Stop();
    }
}

