using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
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
    public void Select()
    {
        InventoryManager.instance.selectItemID = item.ID;
        if (item.type == ItemType.weapon)
        {
            PlayerController2D.instance.ChangeAnimator(1);
        }
    }
    public void DeSelect()
    {
        InventoryManager.instance.selectItemID = "";
        if (item.type == ItemType.weapon)
        {
            PlayerController2D.instance.ChangeAnimator(0);
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (item.type == ItemType.note)
        {
            InventoryManager.instance.NoteUI.SetActive(true);
            InventoryManager.instance.noteText.text = item.noteText;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        countText.gameObject.SetActive(false);
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousepos;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
        transform.position = transform.parent.position;
        RefreshCount();
    }
}
