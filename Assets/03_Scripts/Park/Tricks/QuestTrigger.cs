using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour
{
    public Collider2D col;
    public bool triggerOn;
    void Update()
    {
        if (!triggerOn && QuestManager.instance.CanClearQuest())
        {
            triggerOn = true;
            col.enabled = true;
        }
    }
}
