using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseOver : MonoBehaviour
{

    private void Update()
    {

       

        
    }


    void OnMouseHover()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("Mouse is hovering over a GameObject.");
    }
    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        Debug.Log("Mouse is no longer on GameObject.");
    }
}










