using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class reCaptchaImage : MonoBehaviour, IPointerClickHandler
{
    public int ID;
    public reCaptcha reCapUI;
    public Image image;
    public List<Sprite> sprites;
    private void Start() {
        image = GetComponent<Image>();
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        SwapImage();
    }
    public void SwapImage()
    {
        image.sprite = image.sprite == sprites[0] ? sprites[1] : sprites[0];
        if (image.sprite == sprites[1])
        {
            reCapUI.inputs[ID] = true;
        }
        else
        {
            reCapUI.inputs[ID] = false;
        }
    }
}
