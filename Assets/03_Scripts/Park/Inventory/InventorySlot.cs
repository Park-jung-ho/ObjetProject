using System;
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
            InventoryItem CurrentinventoryItem = transform.GetChild(0).GetComponent<InventoryItem>();
            if (inventoryItem.item.name == CurrentinventoryItem.item.name)
            {
                int moveCnt = Math.Min(inventoryItem.count,CurrentinventoryItem.MaxCount - CurrentinventoryItem.count);
                CurrentinventoryItem.count += moveCnt;
                inventoryItem.count -= moveCnt;
                CurrentinventoryItem.RefreshCount();
                inventoryItem.RefreshCount();
                if (inventoryItem.count == 0)
                {
                    Destroy(inventoryItem.gameObject);
                }
                return;
            }

            CurrentinventoryItem.parentAfterDrag = inventoryItem.parentAfterDrag;
            transform.GetChild(0).SetParent(inventoryItem.parentAfterDrag);
            CurrentinventoryItem.transform.position = inventoryItem.parentAfterDrag.position;
            inventoryItem.parentAfterDrag = transform;
        }
    }
}
