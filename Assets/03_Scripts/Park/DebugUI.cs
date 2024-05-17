using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebugUI : MonoBehaviour
{
    public TMP_Text GameType;
    public TMP_Text storyNodeName;

    void Start()
    {
        
    }

    void Update()
    {
        GameType.text = GameManager.instance.gameState.ToString();
        storyNodeName.text = GameManager.instance.currentStoryNode.name;
    }
}
