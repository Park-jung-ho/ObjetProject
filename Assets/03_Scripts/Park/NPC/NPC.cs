using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, interactable2D
{
    public interactType type {get; set;}
    private QuestState questState;

    public SpriteRenderer questStateSprite;
    public Dialog defaultDialog;
    public Dialog storyDialog;
    public Dialog questNotClear;
    public Dialog questClear;

    private bool isInteractable = false;

    [SerializeField]
    private bool questOn;
    void Awake()
    {
        type = interactType.NPC;
        
    }
    void Start()
    {

    }

    void Update()
    {
        
    }
    public void trigger(bool can)
    {
        isInteractable = can;
    }
    public bool CanClick()
    {
        return isInteractable;
    }
    public void Interact()
    {
        if (storyDialog == null)
        {
            DialogManager.instance.StartDialog(defaultDialog);
            return;
        }
        if (questState == QuestState.None ||
            questState == QuestState.CanStart)
        {
            DialogManager.instance.StartDialog(storyDialog);
            return;
        }
        if (questState == QuestState.Started)
        {
            DialogManager.instance.StartDialog(questNotClear);
            return;
        }
        if (questState == QuestState.CanEnd)
        {
            DialogManager.instance.StartDialog(questClear);
            QuestManager.instance.EndQuest();
            return;
        }
    }
    
    public void SetNewDialog(Dialog start)
    {
        storyDialog = start;
        
        ChangeQuestState(QuestState.None);
    }
    public void SetNewQuest(Dialog start, Dialog notend, Dialog canend)
    {
        storyDialog = start;
        questNotClear = notend;
        questClear = canend;
        ChangeQuestState(QuestState.CanStart);
    }
    public void ChangeQuestEndDialog(Dialog canend)
    {
        questClear = canend;
    }
    public bool CheckState(QuestState newState)
    {
        return questState == newState;
    }
    public void ChangeQuestState(QuestState newState)
    {
        questState = newState;
        if      (questState == QuestState.None)
        {
            SetQuestState(false);
        }
        else if (questState == QuestState.CanStart)
        {
            SetQuestState(true);
            ChangeQuestStateSprite(QuestManager.instance.questSprites[0]);
        }
        else if (questState == QuestState.Started)
        {
            SetQuestState(true);
            ChangeQuestStateSprite(QuestManager.instance.questSprites[1]);
        }
        else if (questState == QuestState.CanEnd)
        {
            SetQuestState(true);
            ChangeQuestStateSprite(QuestManager.instance.questSprites[2]);
        }
    }
    public void SetQuestState(bool isOn)
    {
        questStateSprite.gameObject.SetActive(isOn);
    }
    public void ChangeQuestStateSprite(Sprite sprite)
    {
        questStateSprite.sprite = sprite;
    }
}
