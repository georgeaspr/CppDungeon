using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightIntensity : MonoBehaviour
{
    static public float newIntensity; // The new intensity value you want to set

    private UnityEngine.Rendering.Universal.Light2D light2D;

    private void Start()
    {
        light2D = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        newIntensity = 1f;
    }

    private void Update()
    {
        light2D.intensity = newIntensity;
    }
}
