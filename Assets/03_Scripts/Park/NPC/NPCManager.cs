using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public static NPCManager instance;
    [ShowInInspector]
    public Dictionary<string,NPC_2D> NPCs;
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("매니저 중복");
            Destroy(this);
        }
        NPCs = new Dictionary<string, NPC_2D>();
    }

    void Start()
    {
        setNPCs();
    }

    public void setNPCs()
    {
        foreach (GameObject npcObj in GameObject.FindGameObjectsWithTag("NPC"))
        {
            NPC_2D npc = npcObj.GetComponent<NPC_2D>();
            if (NPCs.ContainsKey(npc.name)) continue;
            NPCs.Add(npc.name,npc);
        }
    }

    public NPC_2D findNPC(string name)
    {
        if (!NPCs.ContainsKey(name)) setNPCs();
        NPC_2D npc = NPCs[name];
        if (npc == null) Debug.LogWarning("Dont find NPC : " + name);
        return npc;
    }
}
