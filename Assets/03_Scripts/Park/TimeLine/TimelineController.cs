using System.Collections;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TimelineController : MonoBehaviour
{
    public static TimelineController instance;
    public PlayableDirector playableDirector;
    public TimelineAsset[] timelines; 
    private bool isLoop = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.LogError("TimelineController 중복!!");
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void playCutscene(int id)
    {
        playableDirector.playableAsset = timelines[id];
        playableDirector.Play();
    }
    public void playCutsceneAuto()
    {
        int id = DialogueLua.GetVariable("timeline").AsInt;
        if (id == -1) return;
        playableDirector.playableAsset = timelines[id];
        playableDirector.Play();
    }
    public void loopWhileDialogue(float t)
    {
        if (!isLoop) return;
        playableDirector.time -= t;
        playableDirector.Evaluate();
    }
    public void setLoop(bool type)
    {
        isLoop = type;
    }
}
