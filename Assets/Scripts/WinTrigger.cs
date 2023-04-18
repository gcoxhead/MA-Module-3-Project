using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WinTrigger : MonoBehaviour
{
    [SerializeField]
    UiController uiController;

    [SerializeField]
    GameBehaviour gameBehaviour;

    [SerializeField]
    public TMP_Text ProgressText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            if (gameBehaviour.hasExcalibur == true)
            {
                uiController.WinScreen();
            }
            else
            {
                ProgressText.text = "You must first recover excalibur before your escape!";
            }
        
    }
}
