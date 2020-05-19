using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoneTransitioner : MonoBehaviour
{

    public Camera cameraToTransitionTo;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Goal")
            GameManager.changeToCamera(cameraToTransitionTo);
    }
}
