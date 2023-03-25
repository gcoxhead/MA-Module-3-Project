using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public UiController uiController;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            uiController.WinScreen();
        
    }
}
