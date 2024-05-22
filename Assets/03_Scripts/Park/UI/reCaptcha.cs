using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class reCaptcha : MonoBehaviour
{
    public List<reCaptchaImage> reCaptchaImages;
    public List<bool> inputs;
    public List<bool> keys;
    
    void Start()
    {
        for (int i = 0; i < reCaptchaImages.Count; i++)
        {
            reCaptchaImages[i].ID = i;
            reCaptchaImages[i].reCapUI = this;
        }
    }
    public void Init()
    {
        foreach (reCaptchaImage image in reCaptchaImages)
        {
            image.InitImage();
            inputs[image.ID] = false;    
        }
    }
    void Update()
    {
        
    }
    
    public void Check()
    {
        bool good = true;
        for (int i = 0; i < 9; i++)
        {
            good = inputs[i] == keys[i];
            if (!good) break;
        }
        if (good)
        {
            // out anim
            Init();
            gameObject.SetActive(false);
            TimelineController.instance.loopOut();
        }
        else
        {
            Init();
        }
    }
}
