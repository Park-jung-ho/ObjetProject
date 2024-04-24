using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameState gameState;
    public TriggerController triggerController;
    
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
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
        Application.targetFrameRate = 60;
    }
    void OnEnable() 
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable() 
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode) 
    {
        if (scene.name == "Title") gameState = GameState.Title;
        if (scene.name != "Title") gameState = GameState.InGame;
        // 씬 로드 시 필요한 실행 여기에
        if (gameState == GameState.InGame)
        {
            triggerController = FindObjectOfType<TriggerController>();
            LoadStory();
        }
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


    void Start()
    {

    }

    void Update()
    {
        
    }
    public void SetStory(int id)
    {
        currentStoryNode = currentStoryNode.NextStoryNode[id];
        LoadStory();
    }
    public void LoadStory()
    {
        if (currentStoryNode == null)
        {
            Debug.Log(string.Format("{0} 의 currentStoryNode 에 StoryNode 없음",this.name));
            return;
        }
    
        if (currentStoryNode.quest != null)
        {
            QuestManager.instance.AddQuest(currentStoryNode.quest);
        }

        // set npc
        if (currentStoryNode.StartNPCName != "")
        {
            // set quest
            if (currentStoryNode.quest == null)
            {
                NPCManager.instance.findNPC(currentStoryNode.StartNPCName).SetNewDialog(currentStoryNode.dialog);
            }
            else
            {
                NPCManager.instance.findNPC(currentStoryNode.StartNPCName).SetNewQuest(currentStoryNode.dialog,
                            currentStoryNode.quest.NotClearDialog,
                            currentStoryNode.quest.ClearDialog);
            }
        }
        // set cutSceneTrigger
        if (triggerController != null)
        {
            foreach (int idx in currentStoryNode.CutSceneTriggeridx)
            {
                triggerController.setCutSceneTriggerOn(idx);    
            }
        }
        else
        {
            Debug.Log("triggerController is null");
        }
        // add here...
    }
}

public enum GameState
{
    Title,
    InGame,
    Pause,
}