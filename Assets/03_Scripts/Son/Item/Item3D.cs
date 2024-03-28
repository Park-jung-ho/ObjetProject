using Sirenix.OdinInspector.Editor;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item")]
public class Item3D : ScriptableObject
{
    public string itemName;
    public ItemType itemType;
    public GameObject itemPrefab;

    public enum ItemType
    {
        Apple,
        Box,
        Used
    }
}
