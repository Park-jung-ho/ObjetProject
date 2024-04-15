using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public static NPCManager instance;
    [ShowInInspector]
    public Dictionary<string,NPC> NPCs;
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("매니저 중복");
            Destroy(gameObject);
        }
        NPCs = new Dictionary<string, NPC>();
    }

    void Start()
    {
        setNPCs();
    }

    public void setNPCs()
    {
        foreach (GameObject npcObj in GameObject.FindGameObjectsWithTag("NPC"))
        {
            NPC npc = npcObj.GetComponent<NPC>();
            if (NPCs.ContainsKey(npc.name)) continue;
            NPCs.Add(npc.name,npc);
        }
    }

    public NPC findNPC(string name)
    {
        if (!NPCs.ContainsKey(name)) setNPCs();
        if (!NPCs.ContainsKey(name))
        {
            Debug.LogWarning("Dont find NPC : " + name);
            return null;
        }
        NPC npc = NPCs[name];
        return npc;
    }
}
