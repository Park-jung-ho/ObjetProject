using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_2D : interactable2D
{
    public int stroyID;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public override void Interact()
    {
        DialogManager.instance.StartDialog(stroyID);
    }
}
