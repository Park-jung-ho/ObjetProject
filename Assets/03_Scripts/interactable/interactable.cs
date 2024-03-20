using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactable2D : MonoBehaviour
{
    public GameObject interactableKey;

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
        EnableKey();
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        DisableKey();
    }
    public bool isActiveOn()
    {
        if (interactableKey.activeSelf) return true;
        return false;
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
