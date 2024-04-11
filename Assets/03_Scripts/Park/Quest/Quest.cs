using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "ObjetProject/Quest")]
public class Quest : ScriptableObject
{
    public string ID;
    public string NotClearDialogID;
    public string ClearDialogID;
    public string npcName;
    public string questTitle;
    public string itemName;
    public int count;
    public int NextStoryID;
}