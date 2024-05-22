using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebugUI : MonoBehaviour
{
    public TMP_Text GameType;
    public TMP_Text storyNodeName;
    private bool boolType;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            gameObject.SetActive(boolType);
            boolType = !boolType;
        }
        GameType.text = GameManager.instance.gameState.ToString();
        storyNodeName.text = GameManager.instance.currentStoryNode.name;
    }
}
