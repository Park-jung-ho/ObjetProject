using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TreeCut : MonoBehaviour
{
    public List<AppleTree> appleTrees;
    public UnityEvent cutEvent;
    
    public bool used;

    // Update is called once per frame
    void Update()
    {
        if (!used)
        {
            int cnt = 0;
            foreach (AppleTree appleTree in appleTrees)
            {
                if (appleTree.cut)
                {
                    cnt++;
                }
            }
            if (cnt == 3)
            {
                cutEvent.Invoke();
                used = true;
            }
        }
    }
}
