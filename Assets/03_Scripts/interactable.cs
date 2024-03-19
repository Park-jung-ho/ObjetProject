using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactable : MonoBehaviour
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
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().SetIneractObject(this);
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().DelIneractObject(this);
        }
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
