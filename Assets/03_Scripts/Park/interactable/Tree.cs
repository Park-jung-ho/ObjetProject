using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

public class AppleTree : MonoBehaviour, interactable2D
{
    public List<Bullet> apples;
    public List<GameObject> drops;

    public interactType type {get; set;}
    [SerializeField]
    private bool isInteractable = false;

    public bool cut;

    private Animator animator;
    [SerializeField]
    private int Maxhp;

    private int hp;
    private bool die;
    private bool cool;
    public bool OnGame;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        type = interactType.tree;
        hp = Maxhp;
    }

    void Update()
    {
        if (OnGame)
        {
            type = interactType.tree;
        }
        else
        {
            type = interactType.None;
        }
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
        if (!OnGame || PlayerController2D.instance.cursor.type != MouseType.tree) return;
        onFall();
    }
    
    public void AppleGameOn()
    {
        OnGame = true;
    }

    // anim
    public void onFall()
    {
        if (die || cool) return;
        cool = true;
        Invoke("cooltime",0.5f);
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
        type = interactType.None;
        OnGame = false;
        foreach (Bullet apple in apples)
        {
            apple.off();
        }
        foreach (GameObject drop in drops)
        {
            drop.SetActive(true);
        }
        cut = true;
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
