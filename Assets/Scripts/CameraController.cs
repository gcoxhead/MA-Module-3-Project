using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField]

    private CinemachineVirtualCamera[] _vCams;
    // Start is called before the first frame update
    void Start()
    {
        ViewCamMenu();
        
    }

  public void ViewCamMenu()
    {
        _vCams[0].enabled = true;
        _vCams[1].enabled = false;
        _vCams[2].enabled = false;
        _vCams[3].enabled = false;
        _vCams[4].enabled = false;
    }

    public void ViewCamChar()
    {
        _vCams[0].enabled = false;
        _vCams[1].enabled = true;
        _vCams[2].enabled = false;
        _vCams[3].enabled = false;
        _vCams[4].enabled = false;
    }

    public void ViewCamShields()
    {
        _vCams[0].enabled = false;
        _vCams[1].enabled = false;
        _vCams[2].enabled = true;
        _vCams[3].enabled = false;
        _vCams[4].enabled = false;
    }

    public void ViewCamSwords()
    {
        _vCams[0].enabled = false;
        _vCams[1].enabled = false;
        _vCams[2].enabled = false;
        _vCams[3].enabled = true;
        _vCams[4].enabled = false;

    }

    public void ViewPlayGameCam()
    {
        _vCams[0].enabled = false;
        _vCams[1].enabled = false;
        _vCams[2].enabled = false;
        _vCams[3].enabled = false;
        _vCams[4].enabled = true;
    }
}
