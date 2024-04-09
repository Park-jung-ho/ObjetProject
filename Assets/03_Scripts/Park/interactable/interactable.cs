using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum interactType
{
    NPC,
    Object,
}
public interface interactable2D
{
    public interactType type {get; set;}
    public void Interact();

    public bool CanClick();
}