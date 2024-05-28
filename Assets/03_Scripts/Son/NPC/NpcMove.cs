using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcMove : MonoBehaviour
{
    public enum MoveType
    {
        Move,
        Look
    }
    public float moveSpeed = 3.0f; // 이동 속도
    public Transform moveTarget;
    MoveType moveType;
    GameObject player;
    float distanceToTarget;
    Animator anim;
    bool isarive;
    void Start()
    {
        anim = GetComponent<Animator>();
        moveType = MoveType.Look;
        player = GameObject.Find("Player");
        distanceToTarget = Vector3.Distance(transform.position, player.transform.position);
        isarive = false;
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(transform.position, player.transform.position);
        if (moveType == MoveType.Move)
        {
            if (isarive) return;
            Debug.Log("Move");
            Vector3 direction = (moveTarget.transform.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
            // target의 위치로 부드럽게 이동
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, moveTarget.position, step);
            if (distanceToTarget > 8f) moveType = MoveType.Look;
            anim.SetBool("isWalk", true);
        }

        if (moveType == MoveType.Look)
        {
            Debug.Log("Look");
            Vector3 direction = (player.transform.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
            if (distanceToTarget < 8f) moveType = MoveType.Move;
            anim.SetBool("isWalk", false);
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Target")
        {
            isarive = true;
            moveType = MoveType.Look;
        }
    }
}
