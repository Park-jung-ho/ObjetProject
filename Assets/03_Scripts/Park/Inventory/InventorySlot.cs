using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
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
}
