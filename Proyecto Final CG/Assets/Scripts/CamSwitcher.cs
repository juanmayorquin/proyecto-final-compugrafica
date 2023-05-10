using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CamSwitcher 
{
    public static List<CinemachineFreeLook> cameras = new List<CinemachineFreeLook>();
    public static CinemachineFreeLook activeCamera = null;

    public static void SwitchCamera(CinemachineFreeLook cam)
    {
        cam.Priority = 10;
        activeCamera = cam;

        foreach (CinemachineFreeLook c in cameras)
        {
            if (c != cam)
            {
                c.Priority = 0;
            }
        }
    }
}
