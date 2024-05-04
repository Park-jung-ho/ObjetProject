using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignAnim : MonoBehaviour
{
    public void OnUI()
    {
        transform.GetChild(1).gameObject.SetActive(true);
    }

    public void OffUI()
    {
        gameObject.SetActive(false);
        PlayerController2D.instance.ChangeState(PlayerState.play);
    }
}
