using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactable2D : MonoBehaviour
{

    public GameObject interactableKey;
    public ObjectType type;
    private bool isInteractable = false;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public virtual void Interact()
    {
        Debug.Log(this.name);
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        isInteractable = true;
        // EnableKey();
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        isInteractable = false;
        // DisableKey();
    }
    public bool CanClick()
    {
        return isInteractable;
    }
    public void EnableKey()
    {
        interactableKey.SetActive(true);
    }
    public void DisableKey()
    {
        interactableKey.SetActive(false);
    }
}

public enum ObjectType
{
    npc,
    item,
}