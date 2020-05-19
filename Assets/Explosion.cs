using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    public float explosionRadius = 10f;
    public float explosionForce = 100f;
    public float upwardsModifier = 3f;

    private bool exploded = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !exploded)
        {
            explode();
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

    public void explode()
    {
        exploded = true;
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        GameObject shopper;
        ShopperController sc;
        foreach (Collider c in colliders)
        {

            if (c.gameObject.tag == "Shopper")
            {
                shopper = c.gameObject;
                sc = shopper.GetComponent<ShopperController>();
                sc.killShopper();
                sc.hipsRB.AddExplosionForce(explosionForce, transform.position, explosionRadius, upwardsModifier);
            }
        }
        Destroy(gameObject);
    }
}
