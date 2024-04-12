using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeApple3d : MonoBehaviour
{
    public GameObject apple3d;

    void Update()
    {
        transform.position = PlayerController2D.instance.transform.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("apple"))
        {
            Vector3 newpos = other.transform.position;
            newpos.z = 0f;
            GameObject newapple = Instantiate(apple3d,other.transform.parent);
            newapple.transform.position = newpos;
            other.gameObject.SetActive(false);
        }
    }
}
