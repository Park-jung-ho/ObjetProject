using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_2D : MonoBehaviour, interactable2D
{
    public int stroyID;
    public int questNotClear;
    public int questClear;

    private bool isInteractable = false;

    [SerializeField]
    private bool questOn;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public bool CanClick()
    {
        return isInteractable;
    }
    public void Interact()
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
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        isInteractable = true;
        // EnableKey();
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        isInteractable = false;
        // DisableKey();
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
