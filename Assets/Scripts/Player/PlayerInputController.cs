using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    public PlayerInput PlayerInput;

    private Rigidbody2D Rigidbody2D;

    private SpriteRenderer spriteRenderer;

    [HideInInspector] public Vector2 MoveDirection;

    [HideInInspector] public Vector2 DushDirection;

    private Vector2 inputDirection;

    [Header("移动参数")]
    public float Speed;

    [Header("跳跃参数")]
    public float JumpForce;

    public float JumpForcedown;

    public float JumpLimitFactor;


    [Header("冲刺参数")]
    public float DushSpeed;//由于实现不同，此速度不宜太快

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
        PlayerInput.GamePlay.Jump.canceled += LeaveButton;
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
        Rigidbody2D.AddForce(JumpForce * transform.up, ForceMode2D.Impulse);

        Debug.Log("JUMP!");
    }

    private void LeaveButton(InputAction.CallbackContext context)
    {
        if(Rigidbody2D.velocity.y >= JumpLimitFactor)
            Rigidbody2D.AddForce(JumpForcedown * Vector2.down, ForceMode2D.Impulse);
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
