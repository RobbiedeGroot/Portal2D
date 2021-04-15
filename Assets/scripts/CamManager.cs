using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamManager : MonoBehaviour
{

public CinemachineVirtualCamera Playercam;
public CinemachineVirtualCamera OverviewCam;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)){
            OverviewCam.Priority = OverviewCam.Priority * -1;
        }

        if(Input.GetKeyUp(KeyCode.Tab)){
            OverviewCam.Priority = OverviewCam.Priority * -1;
        }
    }
}
