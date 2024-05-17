using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlitchController : MonoBehaviour
{
    public UnityEvent Onshake;
    public Material mat;
    public float Vignette;
    // Update is called once per frame
    void Update()
    {
        mat.SetFloat("_Vignette",Vignette);
    }

    public void animEvent()
    {
        Onshake.Invoke();
    }
    void OnDestroy()
    {
        mat.SetFloat("_Vignette",0);
    }
}
