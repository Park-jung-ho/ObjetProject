using System.Collections;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TimelineController : MonoBehaviour
{
    public static TimelineController instance;
    public PlayableDirector playableDirector;
    public TimelineAsset[] timelines; 
    private bool isLoop = false;

    private double LoopTime;

    [ShowInInspector]
    private double LoopOutTime;

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

    public void playCutscene(int id)
    {
        playableDirector.playableAsset = timelines[id];
        playableDirector.Play();
    }
    public void playCutscene(PlayableAsset tl)
    {
        playableDirector.playableAsset = tl;
        playableDirector.Play();
    }
    public void playCutsceneAuto()
    {
        int id = DialogueLua.GetVariable("timeline").AsInt;
        if (id == -1) return;
        playableDirector.playableAsset = timelines[id];
        playableDirector.Play();
    }

    public void loop()
    {
        if (!isLoop) return;
        playableDirector.time = LoopTime;
        playableDirector.Evaluate();
    }
    public void loopOut()
    {
        isLoop = false;
        playableDirector.time = LoopOutTime;
        playableDirector.Evaluate();
    }

    public void SetLoopTime()
    {
        LoopTime = playableDirector.time;
    }
    public void SetLoopOutTime(float t)
    {
        LoopOutTime = t;
    }

    public void setLoop(bool type)
    {
        isLoop = type;
    }
    
}
