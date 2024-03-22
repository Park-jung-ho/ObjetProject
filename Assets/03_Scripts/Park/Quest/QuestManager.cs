using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;


public class QuestManager : SerializedMonoBehaviour
{
    public static QuestManager instance;

    public Dictionary<string,Quest> questList;

    [Title("UI")]
    public GameObject QuestUI;
    public TMP_Text questTitle;
    public TMP_Text questItemCount;

    [SerializeField]
    private Quest currentQuest;
    public int currentCount;

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
        questTitle.text = currentQuest.questTitle;
        questItemCount.text = currentCount.ToString() + " / " + currentQuest.count.ToString();
        questItemCount.color = Color.white;
        QuestUI.SetActive(true);
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
            }
        }
    }
    public void EndQuest()
    {
        currentQuest = null;
        QuestUI.SetActive(false);
    }
}
