using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController2D : MonoBehaviour
{
    [SerializeField]
    public PlayerState state = PlayerState.play;
    
    public static PlayerController2D instance;
    public Mouse cursor;
    private Vector3 moveInput;
    public float moveSpeed;

    private Rigidbody2D rigidbody2D;
    private Animator animator;
    private PlayerInput playerInput;

    
    [SerializeField]
    private interactable2D InteractingObject;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("Player 중복!");
            Destroy(this);
        }
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
    }
    void Start()
    {

    }
    
    void Update()
    {

    }
    
    void FixedUpdate()
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
        if (state == PlayerState.dialog) return;

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
    void OnClick()
    {
        if (state == PlayerState.play) cursor.Onclick();
        else if (state == PlayerState.dialog) DialogManager.instance.OnClick();
    }

    public void ChangeState(PlayerState newState)
    {
        state = newState;
    }
    public PlayerState CurrentState()
    {
        return state;
    }
}

public enum PlayerState
{
    play,
    dialog,
}