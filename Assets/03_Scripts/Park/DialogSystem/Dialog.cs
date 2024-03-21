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
    public int next;
    public string text;

    public Choice[] choices;
}

[System.Serializable]
[CreateAssetMenu(menuName = "ObjetProject/Dialog")]
public class Dialog : ScriptableObject
{
    public Sprite image;
    public string name;
    public int ID;
    public DialogText[] sentences;
}
