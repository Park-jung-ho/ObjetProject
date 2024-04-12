using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Apple : MonoBehaviour, interactable2D
{
    public interactType type {get; set;}
    public Item item;
    [SerializeField]
    private bool isInteractable = false;

    void Start()
    {
        type = interactType.Object;
    }

    void Update()
    {
        
    }
    public void trigger(bool can)
    {
        isInteractable = can;
    }
    public bool CanClick()
    {
        return isInteractable;
    }
    public void Interact()
    {
        bool successToInven = InventoryManager.instance.AddItem(item);
        if (successToInven) GoToInven();
    }

    public void GoToInven()
    {
        gameObject.SetActive(false);

        Invoke(nameof(gotoTree),5f);
    }

    public void gotoTree()
    {
        gameObject.SetActive(true);
    }
}
