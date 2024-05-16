using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class reCaptcha : MonoBehaviour
{
    public List<reCaptchaImage> reCaptchaImages;
    public List<bool> inputs;
    public List<bool> keys;
    public Button button;
    
    void Start()
    {
        for (int i = 0; i < reCaptchaImages.Count; i++)
        {
            reCaptchaImages[i].ID = i;
        }
    }
    
    void Update()
    {
        if (inputs == keys)
        {
            
        }
    }
}
