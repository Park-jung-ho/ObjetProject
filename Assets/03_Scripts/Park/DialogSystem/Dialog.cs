using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum DialogType
{
    Text,
    Choice,
};

[System.Serializable]
public struct DialogText
{
    public DialogType dialogType;
    public string text;
    public string[] choices;
}

[System.Serializable]
[CreateAssetMenu(menuName = "ObjetProject/Dialog")]
public class Dialog : ScriptableObject
{
    public Sprite image;
    public string name;
    public DialogText[] sentences;
}
