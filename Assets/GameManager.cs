using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static Camera currentCamera { get; private set; }

    public Text timerText;
    public Canvas gameOverCanvas;
    public Text timeSurvivedText;
    public Text shoppersKilledText;

    bool gameOver = false;

    public static int shoppersKilled = 0;

    private void Start()
    {
        currentCamera = Camera.main;
    }

    private void Update()
    {
        if (!gameOver)
        timerText.text = Time.timeSinceLevelLoad.ToString("00.00");
    }

    public static void changeToCamera(Camera cam)
    {
        currentCamera.gameObject.SetActive(false);
        cam.gameObject.SetActive(true);
        currentCamera = cam;
    }

    public void GameOver()
    {
        gameOver = true;
        //Show GameOver UI
        timerText.text = "";
        gameOverCanvas.gameObject.SetActive(true);

        timeSurvivedText.text = Time.timeSinceLevelLoad.ToString("00.00");
        shoppersKilledText.text = shoppersKilled.ToString();

    }

    public void restartLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        ShopperSpawn.currentNumberOfShoppers = 0;
        shoppersKilled = 0;
    }
}
