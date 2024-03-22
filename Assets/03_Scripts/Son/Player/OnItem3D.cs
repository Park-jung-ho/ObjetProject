using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class OnItem3D : MonoBehaviour
{
    public bool[] isItems;
    public GameObject[] items;
    void Start()
    {

    }
    void Update()
    {

    }
    public void ItemChange(string typeName)
    {


        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].name == typeName.ToString())
                items[i].SetActive(true);
            else
                items[i].SetActive(false);
        }

    }
}
