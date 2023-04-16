using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FadeUI : MonoBehaviour
{
    private bool isFaded = false;
    private int fadeInAmount = 0;
    private int fadeOutAmount = 1;

    [SerializeField] private float fadeInDuration = 2;
    [SerializeField] private float fadeOutDuration = 2;

   
    [SerializeField] private CanvasGroup myFadingGroup;

    public void Fader()
    {
        isFaded = !isFaded;

        if (isFaded)
        {
            myFadingGroup.DOFade(fadeInAmount, fadeInDuration);
        }
        else
        {
            myFadingGroup.DOFade(fadeOutAmount, fadeOutDuration);
        }
    }
}
