using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public BulletController bulletController;
    public float speed;
    public Vector3 pos;


    void Start()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        transform.position += pos * (speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            bulletController.pushStack(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Debug.Log("OUT");
        bulletController.pushStack(gameObject);
    }
}
