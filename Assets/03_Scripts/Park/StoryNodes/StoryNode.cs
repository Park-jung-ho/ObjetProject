using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "ObjetProject/StoryNode")]
public class StoryNode : ScriptableObject
{
    public string NodeID;
    public string StartNPCName;
    public Dialog dialog;
    public Quest quest;
    public List<int> CutSceneTriggeridx;
    public StoryNode[] NextStoryNode;
}