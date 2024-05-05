using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Tilemaps;



[CreateAssetMenu(menuName = "ObjetProject/Item")]
public class Item : ScriptableObject
{
    [EnumToggleButtons]
    public ItemType type;
    [ShowIf("type",ItemType.note)]
    [TextArea(4, 10)]
    public string noteText;
    
    public Sprite image;
    public string ID;
    public bool stackable = true;
}

public enum ItemType
{
    item,
    questItem,
    note,

}