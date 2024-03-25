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
        if (Input.GetKeyDown(KeyCode.Q) && isItem) DropItem(lastItemNum);
    }
    public void ItemChange(string typeName)
    {

        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].name == typeName.ToString())
            {
                if (isItem) DropItem(i);
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
        Instantiate(dropItems[itemnum], this.transform.position, Quaternion.identity);
        foreach (GameObject item in items)
        {
            item.SetActive(false);
        }
        isItem = false;
    }
}
