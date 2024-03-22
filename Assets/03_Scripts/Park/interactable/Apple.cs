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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interact()
    {
        GetComponent<DOTweenAnimation>().DOPlayById("get");
        InventoryManager.instance.AddItem(item);
    }

    public void GoToInven()
    {
        gameObject.SetActive(false);
    }
}
