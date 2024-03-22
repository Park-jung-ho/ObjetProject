using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;

    [SerializeField]
    private int selectedSlot = -1;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("매니저중복");
            Destroy(this);
        }
    }

    [Button]
    public void ChangeSelectedSlot(int slotIdx)
    {
        if (selectedSlot > -1) inventorySlots[selectedSlot].DeSelect();
        inventorySlots[slotIdx].Select();
        selectedSlot = slotIdx;
    }

    [Button]
    public bool AddItem(Item item)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem slotItem = slot.GetComponentInChildren<InventoryItem>();
            if (slotItem != null &&
                slotItem.item.stackable &&
                slotItem.item == item &&
                slotItem.count < slotItem.MaxCount)
            {
                slotItem.count++;
                slotItem.RefreshCount();
                QuestManager.instance.isQuestItem(item.ID);
                return true;
            }
            if (slotItem == null)
            {
                SpawnNewItem(item, slot);
                QuestManager.instance.isQuestItem(item.ID);
                return true;
            }
        }
        return false;
    }

    public int FindItem(string ItemID)
    {
        foreach (InventorySlot slot in inventorySlots)
        {
            InventoryItem slotItem = slot.GetComponentInChildren<InventoryItem>();
            if (slotItem != null &&
                slotItem.item.ID == ItemID)
            {
                return slotItem.count;
            }
        }
        return 0;
    }


    public void SpawnNewItem(Item item, InventorySlot slot)
    {
        GameObject newItem = Instantiate(inventoryItemPrefab,slot.transform);
        InventoryItem inventoryItem = newItem.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }
}
