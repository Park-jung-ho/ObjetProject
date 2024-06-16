using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SignObject : MonoBehaviour, interactable2D
{
    public interactType type {get; set;}

    public GameObject signUI;
    public TMP_Text textUI;
    public string text;

    [SerializeField]
    private bool isInteractable = false;

    private Animator animator;

    void Start()
    {
        type = interactType.sign;
        animator = signUI.GetComponent<Animator>();
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
        PlayerController2D.instance.ChangeState(PlayerState.sign);
        signUI.SetActive(true);
        textUI.text = text;
        animator.SetTrigger("IsOn");
        AudioManager.instance.PlaySFX("UIon");
    }
    public void exitSign()
    {
        AudioManager.instance.PlaySFX("UIoff");
        textUI.text = "";
        animator.SetTrigger("IsOff");
    }
}
