using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopperSpawn : MonoBehaviour
{

    public GameObject shopperPrefab;
    public static int maxShoppers = 50;
    public static int currentNumberOfShoppers = 0;

    [Range(1, 5)]
    public int spawnPerSecond;

    private bool runningRoutine = false;
    private bool isSpawning = false;

    public void Start()
    {
        toggleSpawning();
    }

    public void toggleSpawning()
    {
        isSpawning = !isSpawning;
        if (isSpawning && !runningRoutine) StartCoroutine(spawnPrefab());
    }


    IEnumerator spawnPrefab()
    {
        runningRoutine = true;
        yield return new WaitForSeconds((float)1 / spawnPerSecond);
        if (isSpawning)
        {
            if (currentNumberOfShoppers < maxShoppers)
            {
                GameObject shopper = Instantiate(shopperPrefab, transform.position, transform.rotation);
                int characterModel = Random.Range(0, 8);
                shopper.transform.GetChild(characterModel).gameObject.SetActive(true);
                GameObject goalObj = GameObject.FindGameObjectWithTag("Goal");
                if (goalObj)
                    shopper.GetComponent<ShopperController>().goal = goalObj.transform;
                currentNumberOfShoppers++;
            }
            
            StartCoroutine(spawnPrefab());
        }
        else
        {
            runningRoutine = false;
        }
    }
}
