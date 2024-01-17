using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    public PlayerInput PlayerInput;

    public Rigidbody2D Rigidbody2D;

    private SpriteRenderer spriteRenderer;

    [HideInInspector] public Vector2 MoveDirection;

    [HideInInspector] public Vector2 DushDirection;

    private Vector2 inputDirection;

    public float Speed;

    public float JumpForce;

    public float JumpFactor;

    public float DushSpeed;
    [HideInInspector] public float DushTapTime;
    public float DushTime;
    public float DushCD;

    [HideInInspector] public bool isDushAble;

    [HideInInspector] public bool isDush;

    [HideInInspector] public bool isMoveAble;

    [HideInInspector] public bool isJumpAble;
    // Start is called before the first frame update

    private void Awake()
    {
        
        isMoveAble = true;
        isDushAble = true;
        PlayerInput = new PlayerInput();
        Rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        PlayerInput.GamePlay.Jump.started += Jump;
        PlayerInput.GamePlay.Dush.started += DushTap;
        
    }

    private void OnEnable()
    {
        PlayerInput.Enable();
    }

    private void OnDisable()
    {
        PlayerInput.Disable();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetMoveDirection();
    }

    private void FixedUpdate()
    {
        DushControll();
        Dush();


        if (isMoveAble) 
        {
            Move();
        }
    }

    private void Move()
    {
        if(isMoveAble)
        {
            Rigidbody2D.velocity = new Vector2(Speed*MoveDirection.x*Time.deltaTime, Rigidbody2D.velocity.y);
        }

        if(MoveDirection.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if(MoveDirection.x < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    private void GetMoveDirection()
    {
        inputDirection = PlayerInput.GamePlay.Move.ReadValue<Vector2>();
        if (inputDirection.x > 0)
            MoveDirection.x = 1;
        else if(inputDirection.x < 0)
            MoveDirection.x = -1;
        else MoveDirection.x = 0;
    }

    private void GetDushDirection()
    {
        if(PlayerInput.GamePlay.Move.ReadValue<Vector2>() != Vector2.zero)
            DushDirection = PlayerInput.GamePlay.Move.ReadValue<Vector2>().normalized;
        else
        {
            if (spriteRenderer.flipX != true)
            {
                DushDirection.x = 1;
                DushDirection.y = 0;
            }

            else
            {
                DushDirection.x = -1;
                DushDirection.y = 0;
            }
        }
    }

    private void Jump(InputAction.CallbackContext context)
    {
        Rigidbody2D.AddForce(JumpFactor*JumpForce * transform.up, ForceMode2D.Impulse);
        Debug.Log("JUMP!");
    }

    private void DushTap(InputAction.CallbackContext context)
    {
        GetDushDirection();
        if(isDushAble) 
        {
            isDush = true;
            DushTapTime = Time.time;
            isDushAble = false;
        }

    }

    private void DushControll()
    {
        if(isDush)
        {
            if(Time.time - DushTapTime >= DushTime)
                isDush = false;
        }
        if(!isDushAble)
        {
            if (Time.time - DushTapTime >= DushCD)
                isDushAble = true;
        }
    }

    private void Dush()
    {
        if(isDush)
        {
            Rigidbody2D.position += DushDirection * DushSpeed*Time.deltaTime;
        }
    }
}
