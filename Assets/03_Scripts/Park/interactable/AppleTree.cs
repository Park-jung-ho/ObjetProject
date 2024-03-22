using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class AppleTree : interactable2D
{
    public GameObject Apple;
    public int appleCount = 10;
    public string Interact_quest_ID;

    public Stack<GameObject> apples;

    void Start()
    {
        apples = new Stack<GameObject>();
        for (int i = 0; i < appleCount; i++)
        {
            GameObject apple = Instantiate(Apple,transform);
            apple.transform.position = new Vector2(transform.position.x,transform.position.y + 1);
            apples.Push(apple);
            apple.SetActive(false);
        }
    }

    void Update()
    {
        
    }

    public override void Interact()
    {
        base.Interact();
        if (apples.Count == 0) return;
        GameObject apple = apples.Pop();
        apple.SetActive(true);
        apple.GetComponent<DOTweenAnimation>().DOPlayById("drop");
        apple.GetComponent<interactable2D>().enabled = true;
    }
}
