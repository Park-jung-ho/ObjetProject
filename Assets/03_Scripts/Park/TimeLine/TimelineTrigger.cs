using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimelineTrigger : MonoBehaviour
{
    public UnityEvent TriggerOn;
    public int cutsceneID;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            TimelineController.instance.playCutscene(cutsceneID);
            TriggerOn?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
