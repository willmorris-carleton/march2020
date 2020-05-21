using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxBottleManager : MonoBehaviour
{

    public static int maxBottles = 3;

    private static Queue<GameObject> bottleQueue = new Queue<GameObject>();
    private static int numBottles = 0;

    public void AddBottle(GameObject bottle)
    {
        bottleQueue.Enqueue(bottle);
        numBottles++;
        if (numBottles >= 10) 
        {
            GameObject bottleToBeRemoved = bottleQueue.Dequeue();
            if (bottleToBeRemoved != null)
                Destroy(bottleToBeRemoved);
        }
    }
}
