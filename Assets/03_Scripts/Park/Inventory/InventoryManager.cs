using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;

    public GameObject NoteUI;
    public TMP_Text noteText;


    [SerializeField]
    private int selectedSlot;

    public string selectItemID;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("매니저중복");
            Destroy(gameObject);
        }
    }
    void Start()
    {
        ChangeSelectedSlot(selectedSlot);
        int idx = 0;
        foreach (InventorySlot slot in inventorySlots)
        {
            slot.idx = idx++;
        }
    }
    void Update()
    {
        getKeyNum();
        float wheel = Input.GetAxis("Mouse ScrollWheel");
        if (wheel < 0)
        {
            int newidx = selectedSlot + 1 == 8 ? 0 : selectedSlot + 1;
            ChangeSelectedSlot(newidx);
        }
        if (wheel > 0)
        {
            int newidx = selectedSlot - 1 == -1 ? 7 : selectedSlot - 1;
            ChangeSelectedSlot(newidx);
        }

    }
    void getKeyNum()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            ChangeSelectedSlot(0);
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            ChangeSelectedSlot(1);
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            ChangeSelectedSlot(2);
        else if (Input.GetKeyDown(KeyCode.Alpha4))
            ChangeSelectedSlot(3);
        else if (Input.GetKeyDown(KeyCode.Alpha5))
            ChangeSelectedSlot(4);
        else if (Input.GetKeyDown(KeyCode.Alpha6))
            ChangeSelectedSlot(5);
        else if (Input.GetKeyDown(KeyCode.Alpha7))
            ChangeSelectedSlot(6);
        else if (Input.GetKeyDown(KeyCode.Alpha8))
            ChangeSelectedSlot(7);
    }
    [Button]
    public void ChangeSelectedSlot(int slotIdx)
    {
        if (selectedSlot == slotIdx) return;
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
        }
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem slotItem = slot.GetComponentInChildren<InventoryItem>();
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
        int newCount = 0;
        foreach (InventorySlot slot in inventorySlots)
        {
            InventoryItem slotItem = slot.GetComponentInChildren<InventoryItem>();
            if (slotItem != null &&
                slotItem.item.ID == ItemID)
            {
                newCount += slotItem.count;
            }
        }
        return newCount;
    }

    public void DelItem(string ItemID, int count)
    {
        foreach (InventorySlot slot in inventorySlots)
        {
            InventoryItem slotItem = slot.GetComponentInChildren<InventoryItem>();
            if (slotItem != null &&
                slotItem.item.ID == ItemID)
            {
                if (count == -1)
                {
                    Destroy(slotItem.gameObject);
                    continue;
                }
                while (true)
                {
                    if (slotItem.count <= 0)
                    {
                        Destroy(slotItem.gameObject);
                        break;
                    }
                    if (count <= 0)
                    {
                        break;
                    }
                    slotItem.count--;
                    count--;
                    slotItem.RefreshCount();
                }
            }
            if (count <= 0) break;
        }
    }

    public void ChangeItemCount(string ItemID, int count)
    {
        bool del = false;
        foreach (InventorySlot slot in inventorySlots)
        {
            InventoryItem slotItem = slot.GetComponentInChildren<InventoryItem>();
            if (slotItem != null &&
                slotItem.item.ID == ItemID)
            {
                if (del)
                {
                    slotItem.count = 0;
                    Destroy(slotItem.gameObject);
                }
                else
                {
                    slotItem.count = count;
                    slotItem.RefreshCount();
                    del = true;
                }
            }
        }

        if (QuestManager.instance != null) QuestManager.instance.setQuestUI();
    }


    public void SpawnNewItem(Item item, InventorySlot slot)
    {
        GameObject newItem = Instantiate(inventoryItemPrefab,slot.transform);
        InventoryItem inventoryItem = newItem.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
        if (inventorySlots[selectedSlot] == slot) inventoryItem.Select();
    }
}
