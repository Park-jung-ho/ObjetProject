using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_2D : interactable2D
{
    public int stroyID;
    public int questNotClear;
    public int questClear;

    [SerializeField]
    private bool questOn;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public override void Interact()
    {
        if (questOn)
        {
            if (QuestManager.instance.canClear())
            {
                DialogManager.instance.StartDialog(questClear);
                QuestManager.instance.EndQuest();
            }
            else
            {
                DialogManager.instance.StartDialog(questNotClear);
            }
        }
        else
        {
            DialogManager.instance.StartDialog(stroyID);
        }
    }

    public void OnQuest()
    {
        questOn = true;
    }
    public void EndQuest()
    {
        questOn = false;
    }
}
