using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UIElements;

public class OnItem3D : MonoBehaviour
{
    bool isItem;
    public GameObject[] items;
    public GameObject[] dropItems;
    int lastItemNum;
    void Start()
    {
        isItem = false;
    }
    void Update()
    {
        if (Input.GetMouseButton(1) && isItem) DropItem(lastItemNum);
    }
    public void ItemChange(string typeName)
    {

        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].name == typeName.ToString())
            {
                if (isItem) DropItem(lastItemNum);
                items[i].SetActive(true);
                lastItemNum = i;
                isItem = true;
            }
            else
                items[i].SetActive(false);
        }

    }
    void DropItem(int itemnum)
    {
        switch (itemnum)
        {
            case 0:
                Instantiate(dropItems[itemnum], items[itemnum].transform.position, Quaternion.identity);
                break;
            case 1:
                dropItems[itemnum].transform.position = items[itemnum].transform.position;
                dropItems[itemnum].SetActive(true);
                break;

        }
        foreach (GameObject item in items)
        {
            item.SetActive(false);
        }
        isItem = false;
    }
}
