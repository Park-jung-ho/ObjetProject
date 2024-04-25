using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "ObjetProject/Quest")]
public class Quest : ScriptableObject
{
    public string ID;
    public string npcName;
    public string questTitle;
    public string itemName;
    public int count;
    public Dialog NotClearDialog;
    public Dialog ClearDialog;
    public bool isTrick;
    [ShowIf("isTrick")]
    public int TrickID;
    [ShowIf("isTrick")]
    public Dialog ChangeClearDialog;
    public int NextStoryID;
}