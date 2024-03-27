using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    [ShowInInspector]
    public Dictionary<string,NPC_2D> NPCs;

    void Awake()
    {
        NPCs = new Dictionary<string, NPC_2D>();
    }
    void Start()
    {
        foreach (GameObject npcObj in GameObject.FindGameObjectsWithTag("NPC"))
        {
            NPC_2D npc = npcObj.GetComponent<NPC_2D>();
            NPCs.Add(npc.name,npc);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
