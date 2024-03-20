using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController2D : MonoBehaviour
{
    public Mouse cursor;
    private Vector3 moveInput;
    public float moveSpeed;

    private Rigidbody2D rigidbody2D;
    private Animator animator;

    [SerializeField]
    private interactable2D InteractingObject;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {

    }
    
    void Update()
    {
        move();
    }
    
    void move()
    {
        // transform.position += moveInput * moveSpeed * Time.deltaTime;
        rigidbody2D.velocity = moveInput * moveSpeed;
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        animator.SetFloat("x",moveInput.x);
        animator.SetFloat("y",moveInput.y);
        animator.SetFloat("speed",moveInput.sqrMagnitude);
        if (moveInput != Vector3.zero)
        {
            animator.SetFloat("lx",moveInput.x);
            animator.SetFloat("ly",moveInput.y);
        }
    }
    void OnInteract(InputValue value)
    {
        Debug.Log(value);
    }
    void OnClick()
    {
        cursor.Onclick();
    }
}
