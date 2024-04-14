using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "ObjetProject/Quest")]
public class Quest : ScriptableObject
{
    public string ID;
    public Dialog NotClearDialog;
    public Dialog ClearDialog;
    public int isTrick;
    public string npcName;
    public string questTitle;
    public string itemName;
    public int count;
    public int NextStoryID;
}