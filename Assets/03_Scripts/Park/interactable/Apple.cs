using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Apple : MonoBehaviour, interactable2D
{
    public interactType type {get; set;}
    public Item item;
    private Vector2 rootPos;
    private bool isInteractable = false;
    private bool onTree;
    private Transform parentTransform;

    void Start()
    {
        onTree = true;
        rootPos = transform.position;
        parentTransform = transform.parent;
        type = interactType.Object;
    }

    void Update()
    {
        
    }

    public bool CanClick()
    {
        return isInteractable;
    }
    public void Interact()
    {
        // GetComponent<DOTweenAnimation>().DOPlayById("get");
        bool successToInven = InventoryManager.instance.AddItem(item);
        if (successToInven) GoToInven();
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (onTree || !other.CompareTag("Player")) return;
        isInteractable = true;
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (onTree || !other.CompareTag("Player")) return;
        isInteractable = false;
    }

    public void OnEndDrop()
    {
        transform.SetParent(transform.root);
        onTree = false;
    }
    public void GoToInven()
    {
        transform.SetParent(parentTransform);
        gameObject.SetActive(false);

        Invoke(nameof(gotoTree),5f);
    }

    public void gotoTree()
    {
        gameObject.SetActive(true);
        transform.position = rootPos;
        transform.parent.GetComponent<AppleTree>().respawnApple(transform);
    }
}
