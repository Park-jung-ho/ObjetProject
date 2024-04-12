using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlitchController : MonoBehaviour
{
    public Material mat;
    public float Vignette;
    // Update is called once per frame
    void Update()
    {
        mat.SetFloat("_Vignette",Vignette);
    }
}
