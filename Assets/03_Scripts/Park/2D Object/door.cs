using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class door : MonoBehaviour
{
    public CinemachineVirtualCamera vcam;
    public Transform targetPos;
    public GameObject loadUI;
    public PlayableAsset loading;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            vcam.MoveToTopOfPrioritySubqueue();
            loadUI.GetComponent<Image>().color = Color.black;
            TimelineController.instance.playCutscene(loading);
            PlayerController2D.instance.transform.position = targetPos.position;
        }
    }
}
