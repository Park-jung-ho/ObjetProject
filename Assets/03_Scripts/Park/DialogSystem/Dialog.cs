using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;


public enum DialogType
{
    Text,
    Choice,
    Quest,
};


[System.Serializable]
public struct Choice
{
    public string text;
    public int next;
}

[System.Serializable]
public struct DialogText
{
    public DialogType dialogType;
    public Sprite image;
    public int next;
    public bool GoToNextStory;
    public int nextStoryNode;
    public bool isCutscene;
    public int cutSceneID;
    [TextArea(4, 10)]
    public string text;
    [FoldoutGroup("choice")]
    public Choice[] choices;
    [FoldoutGroup("quest")]
    public string qusetID;
}

[System.Serializable]
[CreateAssetMenu(menuName = "ObjetProject/Dialog")]
public class Dialog : ScriptableObject
{
    public string NPCname;
    public int ID;
    public bool isQuest = false;
    public DialogText[] sentences;
}