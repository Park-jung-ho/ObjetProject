using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObj : MonoBehaviour
{
    public GameObject rotateObj;
    public Transform objUI;
    public bool m_IsButtonDowning;
    int number = 0;


    public void init_obj()
    {
        int idx = objUI.childCount;
        for (int i = 0; i < idx; i++)
        {
            objUI.GetChild(i).gameObject.SetActive(false);
        }
        rotateObj.SetActive(true);
        rotateObj.transform.rotation = Quaternion.Euler(0f,0f,0f);
    }
    void Update()
    {
        if (m_IsButtonDowning)
        {
            switch (number)
            {
                case 1:
                    rotateObj.transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime *2); // 30도 방향으로 회전
                    break;
                case 2:
                    rotateObj.transform.Rotate(new Vector3(0, -30, 0) * Time.deltaTime *2); // 30도 방향으로 회전
                    break;
                case 3:
                    rotateObj.transform.Rotate(new Vector3(30, 0, 0) * Time.deltaTime *2); // 30도 방향으로 회전
                    break;
                case 4:
                    rotateObj.transform.Rotate(new Vector3(-30, 0, 0) * Time.deltaTime *2); // 30도 방향으로 회전
                    break;
            }
        }
    }

    public void PointerDown(int num)
    {
        m_IsButtonDowning = true;
        number = num;
    }

    public void PointerUp()
    {
        m_IsButtonDowning = false;
        number = 0;
    }
}
