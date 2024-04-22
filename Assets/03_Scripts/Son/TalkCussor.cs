using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkCussor : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (FindAnyObjectByType<PlayerController3D>().isTalk)
        {
            // 현재 마우스 커서 위치를 가져옵니다.
            Vector3 mousePosition = Input.mousePosition;
            // 카메라에서의 거리를 설정하여 마우스 위치를 조정합니다.
            mousePosition.z = 10; // 카메라에서의 거리
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            // 이미지의 위치를 마우스 위치로 설정합니다.
            transform.position = mousePosition;
        }
    }
}
