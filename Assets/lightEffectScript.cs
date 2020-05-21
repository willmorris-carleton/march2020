using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightEffectScript : MonoBehaviour
{
    public Light light;
    void Update()
    {
        light.color = Color.Lerp(Color.white, Color.red, Mathf.Sin(Time.time));
    }
}
