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
    public float KnockBackPower;
    public float KnockBackTime;

    private Rigidbody2D rigidbody2d;
    private Animator animator;
    private PlayerInput playerInput;

    [SerializeField]
    private List<RuntimeAnimatorController> runtimeAnimators;
    
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
            Destroy(gameObject);
        }
        rigidbody2d = GetComponent<Rigidbody2D>();
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
        if (state != PlayerState.sign && state != PlayerState.stunned)
        {
            move();
        }   
    }
    
    void move()
    {
        // transform.position += moveInput * moveSpeed * Time.deltaTime;
        rigidbody2d.velocity = moveInput * moveSpeed;
    }

    void OnMove(InputValue value)
    {
        if (state == PlayerState.dialog ||
            state == PlayerState.sign)
        {
            moveInput = Vector3.zero;
            return;
        }

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

    public void ChangeAnimator(int idx)
    {
        animator.runtimeAnimatorController = runtimeAnimators[idx];
    }
    public void ChangeState(PlayerState newState)
    {
        if (state == newState) return;
        state = newState;
        moveInput = Vector3.zero;
        animator.SetFloat("speed",moveInput.sqrMagnitude);
        rigidbody2d.velocity = Vector2.zero;
    }
    public void ChangeState(PlayerState newState, Vector2 pos)
    {
        if (state == newState) return;
        state = newState;
        moveInput = Vector3.zero;
        animator.SetFloat("speed",moveInput.sqrMagnitude);
        if (state == PlayerState.stunned)
        {
            StartCoroutine(KnockBack(pos));
        }
    }
    public bool CurrentState(PlayerState playerState)
    {
        return playerState == state;
    }

    public void animTrigger(string Triggername)
    {
        animator.SetTrigger(Triggername);
    }

    IEnumerator KnockBack(Vector2 pos)
    {
        float Ktime = 0f;
        if (pos.x <= 0)
        {
            animator.SetTrigger("hitR");
        }
        else
        {
            animator.SetTrigger("hitL");
        }
        while (Ktime < KnockBackTime)
        {
            Ktime += Time.deltaTime;
            rigidbody2d.velocity = pos * KnockBackPower;
            // rigidbody2d.AddForce(pos * KnockBackPower,ForceMode2D.Impulse);
            yield return null;
        }
        // yield return new WaitForSeconds(KnockBackTime);
        ChangeState(PlayerState.play);
    }
    
    [Button]
    public void kbTest(Vector2 pos)
    {
        state = PlayerState.stunned;
        StartCoroutine(KnockBack(pos));
    }
}

public enum PlayerState
{
    play,
    dialog,
    sign,
    stunned,
    death,
    
}