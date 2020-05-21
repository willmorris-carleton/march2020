using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionBehaviour : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Shopper")
        {
            col.gameObject.GetComponent<ShopperController>().killShopper();
        }
    }
}
