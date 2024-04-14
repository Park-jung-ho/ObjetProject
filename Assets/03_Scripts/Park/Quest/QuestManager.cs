using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;


public class QuestManager : SerializedMonoBehaviour
{
    public static QuestManager instance;

    public Dictionary<string,Quest> QuestList;
    public List<Sprite> questSprites;

    [Title("UI")]
    public GameObject QuestUI;
    public TMP_Text questTitle;
    public TMP_Text questItemCount;

    [SerializeField]
    private Quest currentQuest;
    private int currentCount;
    [SerializeField]
    private NPC_2D questNPC;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("매니저 중복");
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
        QuestList = new Dictionary<string, Quest>();
    }

    public void setQuestUI()
    {
        questTitle.text = currentQuest.questTitle;
        currentCount = InventoryManager.instance.FindItem(currentQuest.itemName);

        if (currentCount >= currentQuest.count)
        {
            questItemCount.color = Color.green;
            questNPC.ChangeQuestState(QuestState.CanEnd);
        }
        else
        {
            questItemCount.color = Color.white;
            questNPC.ChangeQuestState(QuestState.Started);
        }

        questItemCount.text = currentCount.ToString() + " / " + currentQuest.count.ToString();
        QuestUI.SetActive(true);
    }

    public void AddQuest(Quest quest)
    {
        if (!QuestList.ContainsKey(quest.name))
        {
            QuestList.Add(quest.name,quest);
        }
    }


    [Button]
    public void StartQuest(string questID)
    {
        currentQuest = QuestList[questID];
        if (currentQuest == null)
        {
            Debug.LogWarning("quest ID -" + questID + "- is null");
            return;
        }
        questNPC = NPCManager.instance.findNPC(currentQuest.npcName);
        
        setQuestUI();
        
        questNPC.ChangeQuestState(QuestState.Started);
    }

    public void isQuestItem(string itemID)
    {
        if (currentQuest != null &&
            currentQuest.itemName == itemID)
        {
            currentCount++;
            setQuestUI();
        }
    }

    public void EndQuest()
    {
        if (currentQuest.isTrick > 0)
        {
            questTrick(currentQuest.isTrick);
            return;
        }
        InventoryManager.instance.DelItem(currentQuest.itemName,currentQuest.count);
        questNPC.ChangeQuestState(QuestState.None);
        QuestUI.SetActive(false);
        currentQuest = null;
    }

    public void questTrick(int num)
    {
        if (num == 1)
        {
            InventoryManager.instance.ChangeItemCount(currentQuest.itemName,5);
            GameManager.instance.triggerController.setCutSceneTriggerOn(1);
        }
        setQuestUI();
    }
}

public enum QuestState
{
    None,
    CanStart,
    Started,
    CanEnd,

}
