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
            Vector2 kpos = (PlayerController2D.instance.transform.position - transform.position).normalized;
            PlayerController2D.instance.ChangeState(PlayerState.stunned,kpos);
            bulletController.pushStack(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        bulletController.pushStack(gameObject);
    }
}
