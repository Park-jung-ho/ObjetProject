using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractRange : MonoBehaviour
{
    public GameObject Object;
    public interactable2D interactable;

    void Start()
    {
        interactable = Object.GetComponent<interactable2D>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        interactable.trigger(true);
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        interactable.trigger(false);
    }
}
