using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public BulletController bulletController;
    public float respawnTime;
    public float delay;
    public float speed;
    public Vector3 pos;

    private Vector2 idlePos;

    [SerializeField]
    private bool isOn;
    void Start()
    {
        // gameObject.SetActive(false);
        idlePos = transform.position;
        StartCoroutine(hide());
    }

    void Update()
    {
        if (isOn) transform.position += pos * (speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && isOn)
        {
            Vector2 kpos = (PlayerController2D.instance.transform.position - transform.position).normalized;
            PlayerController2D.instance.ChangeState(PlayerState.stunned,kpos);
            // bulletController.pushStack(gameObject);
            StartCoroutine(hide());
        }
    }

    IEnumerator hide()
    {
        isOn = false;
        transform.position = idlePos;
        GetComponent<DOTweenAnimation>().DORestart();
        yield return new WaitForSeconds(respawnTime);
        pos = (PlayerController2D.instance.transform.position - transform.position).normalized;
        yield return new WaitForSeconds(delay);
        isOn = true;
    }

    public void off()
    {
        gameObject.SetActive(false);
    }

    void OnBecameInvisible()
    {
        if (gameObject.activeSelf) StartCoroutine(hide());
        // bulletController.pushStack(gameObject);
    }
}
