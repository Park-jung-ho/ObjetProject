using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

public class AppleTree : MonoBehaviour, interactable2D
{
    public List<Bullet> apples;
    public interactType type {get; set;}
    [SerializeField]
    private bool isInteractable = false;



    private Animator animator;
    [SerializeField]
    private int Maxhp;

    private int hp;
    private bool die;
    private bool cool;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        type = interactType.tree;
        hp = Maxhp;
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
        if (PlayerController2D.instance.cursor.type != MouseType.tree) return;
        onFall();
    }
    

    // anim
    public void onFall()
    {
        if (die || cool) return;
        cool = true;
        Invoke("cooltime",0.3f);
        float Px = PlayerController2D.instance.transform.position.x;
        if (hp > 0)
        {
            hp--;
            if (Px <= transform.position.x)
            {
                PlayerController2D.instance.animTrigger("axeR");
            }
            else
            {
                PlayerController2D.instance.animTrigger("axeL");
            }
            GetComponent<DOTweenAnimation>().DORestart();

            return;
        }
        die = true;
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
        // Invoke("respawnTree", 5f);
        foreach (Bullet apple in apples)
        {
            apple.off();
        }
    }

    public void cooltime()
    {
        cool = false;
    }

    public void respawnTree()
    {
        hp = Maxhp;
        animator.SetTrigger("respawn");
        die = false;
    }
}
