using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineTrigger : MonoBehaviour
{
    public int cutsceneID;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            TimelineController.instance.playCutscene(cutsceneID);
            gameObject.SetActive(false);
        }
    }
}
