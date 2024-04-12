using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

public class AppleTree : MonoBehaviour, interactable2D
{
    public interactType type {get; set;}
    public int appleCount = 10;
    public string Interact_quest_ID;
    [SerializeField]
    private bool isInteractable = false;

    [ShowInInspector]
    public Stack<Transform> apples;

    
    void Start()
    {
        apples = new Stack<Transform>();
        for (int i = 0; i < transform.childCount; i++)
        {
            apples.Push(transform.GetChild(i));
        }
        type = interactType.Object;
    }

    void Update()
    {
        
    }
    public void trigger(bool can)
    {
        isInteractable = can;
    }
    public bool CanClick()
    {
        return isInteractable;
    }

    public void Interact()
    {
        if (apples.Count == 0) return;
        Transform apple = apples.Pop();
        
        apple.GetComponent<DOTweenAnimation>().DOPlayById("drop");
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        isInteractable = true;
        // EnableKey();
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        isInteractable = false;
        // DisableKey();
    }

    public void respawnApple(Transform apple)
    {
        apples.Push(apple);
    }
}
