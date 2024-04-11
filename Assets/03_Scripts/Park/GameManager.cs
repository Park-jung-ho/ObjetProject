using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [SerializeField]
    private StoryNode currentStoryNode;

    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("게임매니저 중복");
            Destroy(this);
        }
        DontDestroyOnLoad(this);
        Application.targetFrameRate = 60;
    }

    void Start()
    {
        SetStory(0);
    }

    void Update()
    {
        
    }

    public void SetStory(int id)
    {
        currentStoryNode = currentStoryNode.NextStoryNode[id];
        // set npc
        if (currentStoryNode.StartNPCName != "")
        {
            // set quest
            if (currentStoryNode.quest == null)
            {
                NPCManager.instance.findNPC(currentStoryNode.StartNPCName).SetNewDialog(currentStoryNode.dialog.name);
            }
            else
            {
                NPCManager.instance.findNPC(currentStoryNode.StartNPCName).SetNewQuest(currentStoryNode.quest.name,
                            currentStoryNode.quest.NotClearDialogID,
                            currentStoryNode.quest.ClearDialogID);
            }
        }
        // set cutSceneTrigger
        // add here...
    }
}
