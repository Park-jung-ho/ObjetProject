using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_2D : MonoBehaviour, interactable2D
{
    public interactType type {get; set;}
    private QuestState questState;

    public SpriteRenderer questStateSprite;
    public string DialogID;
    public string questNotClear;
    public string questClear;

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
        if (questState == QuestState.None ||
            questState == QuestState.CanStart)
        {
            DialogManager.instance.StartDialog(DialogID);
        }
        else if (questState == QuestState.Started)
        {
            DialogManager.instance.StartDialog(questNotClear);
        }
        else if (questState == QuestState.CanEnd)
        {
            DialogManager.instance.StartDialog(questClear);
            QuestManager.instance.EndQuest();
        }
    }
    
    public void SetNewDialog(string start)
    {
        DialogID = start;
        
        ChangeQuestState(QuestState.None);
    }
    public void SetNewQuest(string start, string notend, string canend)
    {
        DialogID = start;
        questNotClear = notend;
        questClear = canend;
        ChangeQuestState(QuestState.CanStart);
    }
    public void ChangeQuestState(QuestState newState)
    {
        questState = newState;
        if (questState == QuestState.None)
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
