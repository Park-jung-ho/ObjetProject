using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    private Vector3 moveInput;
    public float moveSpeed;

    private Rigidbody2D rigidbody2D;
    private Animator animator;

    [SerializeField]
    private interactable InteractingObject;

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
    void OnInteract()
    {
        Debug.Log("PRESS E");
        if (InteractingObject == null) return;
        InteractingObject.Interact();
    }

    public void SetIneractObject(interactable obj)
    {
        if (InteractingObject != null) DelIneractObject(InteractingObject);
        InteractingObject = obj;
        obj.EnableKey();
    }
    public void DelIneractObject(interactable obj)
    {
        if (InteractingObject == obj) InteractingObject = null;
        obj.DisableKey();
    }
}
