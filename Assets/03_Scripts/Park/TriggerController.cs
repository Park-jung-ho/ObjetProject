using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    public List<GameObject> Triggers;
    public List<GameObject> CutSceneTriggers;
    
    void Awake()
    {
        foreach (var trigger in Triggers)
        {
            trigger.SetActive(false);
        }    
        foreach (var trigger in CutSceneTriggers)
        {
            trigger.SetActive(false);
        }    
    }
    

    public void setTriggerOn(int[] idxs)
    {
        foreach (var idx in idxs)
        {
            Triggers[idx].SetActive(true);
        }
    }
    public void setCutSceneTriggerOn(int idx)
    {
        CutSceneTriggers[idx].SetActive(true);
    }
}
