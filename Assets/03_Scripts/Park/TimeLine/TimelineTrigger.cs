using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

public class TimelineTrigger : MonoBehaviour
{
    public UnityEvent TriggerOn;
    public PlayableAsset cutscene; 
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (cutscene != null) TimelineController.instance.playCutscene(cutscene);
            TriggerOn?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
