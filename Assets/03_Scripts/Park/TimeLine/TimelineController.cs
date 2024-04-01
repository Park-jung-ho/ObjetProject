using System.Collections;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TimelineController : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public TimelineAsset[] timelines; 


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
    
}
