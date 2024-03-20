using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class AppleTree : interactable
{
    public GameObject Apple;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public override void Interact()
    {
        base.Interact();
        Apple.GetComponent<DOTweenAnimation>().DOPlayById("drop");
        Apple.GetComponent<interactable>().enabled = true;
    }
}
