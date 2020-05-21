using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopperCollisionDetector : MonoBehaviour
{

    public const int MAX_HEALTH = 100;
    public int health = MAX_HEALTH;
    public Light light;
    public GameManager gm;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Shopper")
        {
            ShopperController sc = col.gameObject.GetComponent<ShopperController>();
            if (sc.isAlive)
            {
                sc.killShopper(false);
                health -= 5;
                if (health <= 0)
                {
                    gm.GameOver();
                    Destroy(gameObject);
                }
                updateLightColour();
            }
        }
    }

    void updateLightColour()
    {
        light.color = Color.Lerp(Color.red, Color.white, (float)health/MAX_HEALTH);
    }
}
