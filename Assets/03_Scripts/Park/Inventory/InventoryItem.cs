using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Item item;
    public Image image;
    public TMP_Text countText;
    public int count = 1;
    public int MaxCount = 99;

    public Transform parentAfterDrag;

    public void InitialiseItem(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.image;
        RefreshCount();
    }

    public void RefreshCount()
    {
        countText.text = count.ToString();
        bool textActive = count > 1;
        countText.gameObject.SetActive(textActive);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // image.raycastTarget = false;
        // parentAfterDrag = transform.parent;
        // transform.SetParent(transform.root);
    }
    public void OnDrag(PointerEventData eventData)
    {
        // Vector2 mousepos = Input.mousePosition;
        // Debug.Log(mousepos);    
        // transform.position = mousepos;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        // image.raycastTarget = true;
        // transform.SetParent(parentAfterDrag);
    }
}
