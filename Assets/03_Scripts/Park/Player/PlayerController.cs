using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController2D : MonoBehaviour
{
    public static PlayerController2D instance;
    public Mouse cursor;
    private Vector3 moveInput;
    public float moveSpeed;

    private Rigidbody2D rigidbody2D;
    private Animator animator;
    private PlayerInput playerInput;
    private bool isChangeNow;


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
        isChangeNow = false;
    }
    void Start()
    {

    }
    
    void Update()
    {
        move();
    }

    [Button]
    public void ChangeInputToPlayer()
    {
        playerInput.SwitchCurrentActionMap("Player");
    }
    [Button]
    public void ChangeInputToUI()
    {
        playerInput.SwitchCurrentActionMap("UI");
    }
    
    void move()
    {
        // transform.position += moveInput * moveSpeed * Time.deltaTime;
        rigidbody2D.velocity = moveInput * moveSpeed;
    }
    public void SetInput(bool isOn)
    {
        if (isOn) isChangeNow = true;
        playerInput.enabled = isOn;
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
    void OnClick()
    {
        if (isChangeNow)
        {
            isChangeNow = false;
            return;
        }
        cursor.Onclick();
    }
}
