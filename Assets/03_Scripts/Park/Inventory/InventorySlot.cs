using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public Image image;
    public Color selected, notselected;

    void Awake()
    {
        DeSelect();
    }
    public void Select()
    {
        image.color = selected;
    }
    public void DeSelect()
    {
        image.color = notselected;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            inventoryItem.parentAfterDrag = transform;
        }
        else
        {
            InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            transform.GetChild(0).GetComponent<InventoryItem>().parentAfterDrag = inventoryItem.parentAfterDrag;
            transform.GetChild(0).SetParent(inventoryItem.parentAfterDrag);
            inventoryItem.parentAfterDrag = transform;
        }
    }
}
