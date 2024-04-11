using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;


public class QuestManager : SerializedMonoBehaviour
{
    public static QuestManager instance;

    public Dictionary<string,Quest> questList;
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
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }

    [Button]
    public void StartQuest(string questID)
    {
        currentQuest = questList[questID];
        if (currentQuest == null)
        {
            Debug.LogWarning("quest ID -" + questID + "- is null");
            return;
        }
        questNPC = NPCManager.instance.findNPC(currentQuest.npcName);
        questTitle.text = currentQuest.questTitle;
        currentCount = InventoryManager.instance.FindItem(currentQuest.itemName);
        questItemCount.text = currentCount.ToString() + " / " + currentQuest.count.ToString();
        questItemCount.color = Color.white;
        QuestUI.SetActive(true);
        
        questNPC.ChangeQuestState(QuestState.Started);
    }

    public void isQuestItem(string itemID)
    {
        if (currentQuest != null &&
            currentQuest.itemName == itemID)
        {
            currentCount++;
            questItemCount.text = currentCount.ToString() + " / " + currentQuest.count.ToString();
            if (currentCount == currentQuest.count)
            {
                questItemCount.color = Color.green;
                questNPC.ChangeQuestState(QuestState.CanEnd);
            }
        }
    }

    public void EndQuest()
    {
        InventoryManager.instance.DelItem(currentQuest.itemName,currentQuest.count);
        questNPC.ChangeQuestState(QuestState.None);
        QuestUI.SetActive(false);
        currentQuest = null;
    }
}

public enum QuestState
{
    None,
    CanStart,
    Started,
    CanEnd,

}
