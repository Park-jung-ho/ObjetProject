using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Apple : interactable2D
{
    public Item item;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CircleCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interact()
    {
        // GetComponent<DOTweenAnimation>().DOPlayById("get");
        InventoryManager.instance.AddItem(item);
        GoToInven();
    }

    public void OnEndDrop()
    {
        transform.SetParent(transform.root);
        GetComponent<CircleCollider2D>().enabled = true;
    }
    public void GoToInven()
    {
        gameObject.SetActive(false);
    }
}
