using UnityEngine;
using System.Collections;

// Detects clicks from the mouse and prints a message
// depending on the click detected.

public class MouseClickTest : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Pressed left click.");
        }

        if (Input.GetMouseButton(1))
        {
            Debug.Log("Pressed right click.");
        }

        if (Input.GetMouseButton(2))
        {
            Debug.Log("Pressed middle click.");
        }
    }
}