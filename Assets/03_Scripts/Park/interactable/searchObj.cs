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
    public GameObject Obj3d;
    private spriteOutline spriteOutline;

    public Shader[] mat;
    private SpriteRenderer meshRenderer;

    public int spriteOutlineVal;
    
    void Start()
    {
        type = interactType.search;
        spriteOutline = GetComponent<spriteOutline>();
        meshRenderer = GetComponent<SpriteRenderer>();
        meshRenderer.material = Instantiate(meshRenderer.material);
    }

    void Update()
    {
        if (CanClick())
        {
            meshRenderer.material.shader = mat[1];
            spriteOutline.outlineSize = spriteOutlineVal;
        }
        else
        {
            meshRenderer.material.shader = mat[0];
            spriteOutline.outlineSize = 0;
        }
    }
    public void trigger(bool can)
    {
        isInteractable = can;
    }
    public bool CanClick()
    {
        if (PlayerController2D.instance.cursor.objname != this.name) return false;
        return PlayerController2D.instance.cursor.type == MouseType.search;
    }

    public void Interact()
    {
        UIObj.SetActive(true);
        UIObj.GetComponent<RotateObj>().rotateObj = Obj3d;
        UIObj.GetComponent<RotateObj>().init_obj();
        PlayerController2D.instance.cursor.DontChangeCursor = true;
        PlayerController2D.instance.cursor.CanSearch3D = true;
    }
    public void exitUI()
    {
        PlayerController2D.instance.cursor.DontChangeCursor = false;
        PlayerController2D.instance.cursor.CanSearch3D = false;
    }
}
