using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reCaptchaImage : MonoBehaviour
{
    public int ID;
    public reCaptcha reCapUI;
    public SpriteRenderer spriteRenderer;
    public List<Sprite> sprites;
    private void Start() {
        reCapUI = transform.parent.GetComponent<reCaptcha>();
    }
    public void SwapImage()
    {
        spriteRenderer.sprite = spriteRenderer.sprite == sprites[0] ? sprites[0] : sprites[1];
        if (spriteRenderer.sprite == sprites[1])
        {
            reCapUI.inputs[ID] = true;
        }
        else
        {
            reCapUI.inputs[ID] = false;
        }
    }
}
