using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M3d : MonoBehaviour
{
    public Image cursor;
    public Sprite DefaultCursor;
    void Start()
    {
        cursor.sprite = DefaultCursor;
    }
    void Update()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursor.transform.position = pos;
    }
}
