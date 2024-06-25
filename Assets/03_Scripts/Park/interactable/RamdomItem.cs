using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RamdomItem : MonoBehaviour, interactable2D
{
    public interactType type {get; set;}
    public Item item;
    [SerializeField]
    private bool isInteractable = false;

    public UnityEvent TriggerOn;

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
        TriggerOn?.Invoke();
        gameObject.SetActive(false);
    }

}
