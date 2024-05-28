using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkEnd : MonoBehaviour
{
    void OnDisable()
    {
        FindAnyObjectByType<PlayerController3D>().isTalk = false;
        FindAnyObjectByType<ActionController3D>().cusor.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked; // 마우스 커서를 고정
        Cursor.visible = false; // 마우스 커서를 숨김
    }
}
