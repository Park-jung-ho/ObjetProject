using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

public class AppleTree : MonoBehaviour, interactable2D
{
    public interactType type {get; set;}
    [SerializeField]
    private bool isInteractable = false;

    private Animator animator;
    private bool die;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        type = interactType.tree;
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
        onFall();
        //apple.GetComponent<DOTweenAnimation>().DOPlayById("drop");
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        isInteractable = true;
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        isInteractable = false;
    }

    // anim
    public void onFall()
    {
        // check L R
        if (die) return;
        die = true;
        float Px = PlayerController2D.instance.transform.position.x;
        if (Px <= transform.position.x)
        {
            PlayerController2D.instance.animTrigger("axeR");
            animator.SetTrigger("fallR");
        }
        else
        {
            PlayerController2D.instance.animTrigger("axeL");
            animator.SetTrigger("fallL");
        }
        Invoke("respawnTree", 5f);

    }
    public void respawnTree()
    {
        animator.SetTrigger("respawn");
        die = false;
    }
}
