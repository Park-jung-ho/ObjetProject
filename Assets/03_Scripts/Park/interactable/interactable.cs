using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum interactType
{
    NPC,
    Object,
    Door,
    sign,
    tree,


}
public interface interactable2D
{
    public interactType type {get; set;}
    public void Interact();
    public void trigger(bool can);
    public bool CanClick();

}