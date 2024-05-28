using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

public class searchObj : MonoBehaviour, interactable2D
{
    public interactType type {get; set;}
    [SerializeField]
    private bool isInteractable = false;

    public GameObject UIObj;
    private spriteOutline spriteOutline;

    
    void Start()
    {
        type = interactType.search;
        spriteOutline = GetComponent<spriteOutline>();
    }

    void Update()
    {
        if (CanClick())
        {
            spriteOutline.outlineSize = 1;
        }
        else
        {
            spriteOutline.outlineSize = 0;
        }
    }
    public void trigger(bool can)
    {
        isInteractable = can;
    }
    public bool CanClick()
    {
        return PlayerController2D.instance.cursor.type == MouseType.search;
    }

    public void Interact()
    {
        UIObj.SetActive(true);
        PlayerController2D.instance.cursor.DontChangeCursor = true;
    }
    public void exitUI()
    {
        PlayerController2D.instance.cursor.DontChangeCursor = false;
    }
}
