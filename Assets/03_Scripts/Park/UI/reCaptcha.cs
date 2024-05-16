using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class reCaptcha : MonoBehaviour
{
    public List<reCaptchaImage> reCaptchaImages;
    public List<bool> inputs;
    public List<bool> keys;
    public GameObject button;
    
    void Start()
    {
        for (int i = 0; i < reCaptchaImages.Count; i++)
        {
            reCaptchaImages[i].ID = i;
            reCaptchaImages[i].reCapUI = this;
        }
    }
    
    void Update()
    {
        bool good = true;
        for (int i = 0; i < 9; i++)
        {
            good = inputs[i] == keys[i];
            if (!good) break;
        }
        if (good)
        {
            button.SetActive(true);
        }
    }
}
