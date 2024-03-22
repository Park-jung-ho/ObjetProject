using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;



[CreateAssetMenu(menuName = "ObjetProject/Item")]
public class Item : ScriptableObject
{
    public ItemType type;
    public Sprite image;
    public string ID;
    public bool stackable = true;
}

public enum ItemType
{
    questItem,

}