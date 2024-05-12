using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadUI : MonoBehaviour
{
    [SerializeField]
    private Door door;
    void Awake()
    {
        gameObject.SetActive(false);
    }
    public void Loading(Door _door)
    {
        door = _door;
        gameObject.SetActive(true);
    }
    public void movePlayer()
    {
        door.move();
    }
    public void End()
    {
        gameObject.SetActive(false);
    }
    public void OffToOn()
    {
        gameObject.GetComponent<Animator>().Play("on");
    }
}
