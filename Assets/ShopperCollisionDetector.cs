using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopperCollisionDetector : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Shopper")
        print("Shopper Entered");
    }
}
