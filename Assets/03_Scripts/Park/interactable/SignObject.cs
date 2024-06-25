using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SignObject : MonoBehaviour, interactable2D
{
    public interactType type {get; set;}

    public GameObject signUI;
    public TMP_Text textUI;


    [TextArea(4, 10)]
    public List<string> texts;

    private int idx;

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
        signUI.GetComponent<SignAnim>().signObject = this;
        idx = 0;
        PlayerController2D.instance.ChangeState(PlayerState.sign);
        signUI.SetActive(true);
        textUI.text = texts[idx];
        animator.SetTrigger("IsOn");
        AudioManager.instance.PlaySFX("UIon");
    }

    public void exitSign()
    {
        if (idx + 1 < texts.Count)
        {
            idx++;
            textUI.text = texts[idx];
            return;
        }
        AudioManager.instance.PlaySFX("UIoff");
        textUI.text = "";
        animator.SetTrigger("IsOff");
    }
}
