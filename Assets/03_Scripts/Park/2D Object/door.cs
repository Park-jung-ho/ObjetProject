using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class Door : MonoBehaviour, interactable2D
{
    public interactType type {get; set;}
    public CinemachineVirtualCamera vcam;
    public Transform targetPos;
    public LoadUI loadUI;

    public bool autoDoor;
    private bool inRange;


    void Awake()
    {
        type = interactType.Door;
    }

    public void trigger(bool can)
    {
        inRange = can;
    }
    public bool CanClick()
    {
        return inRange;
    }

    public void Interact()
    {
        if (!inRange) return;
        doorOpen();
    }

    void doorOpen()
    {
        loadUI.Loading(this);
    }
    public void move()
    {
        vcam.MoveToTopOfPrioritySubqueue();
        PlayerController2D.instance.transform.position = targetPos.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && autoDoor)
        {
            doorOpen();
        }
    }
}
