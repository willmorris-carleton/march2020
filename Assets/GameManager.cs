using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static Camera currentCamera { get; private set; }

    private void Start()
    {
        currentCamera = Camera.main;
    }

    public static void changeToCamera(Camera cam)
    {
        currentCamera.gameObject.SetActive(false);
        cam.gameObject.SetActive(true);
        currentCamera = cam;
    }
}
