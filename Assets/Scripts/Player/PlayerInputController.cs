using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;

public class PlayerInputController : MonoBehaviour
{
    public static PlayerInputController Instance;

    public PlayerInput PlayerInput;

    public Rigidbody2D Rigidbody2D;

    public SpriteRenderer spriteRenderer;

    private PhysicsCheck PhysicsCheck;

    private Character character;

    [HideInInspector] public Vector2 MoveDirection;

    public Vector2 inputDirection;

    [Header("移动参数")]
    public float Speed;

    public bool isLeftOnWall;
    public bool isRightOnWall;

    [Header("跳跃参数")]
    public float JumpForce;

    public float JumpForcedown;

    public float JumpLimitFactor;

    public int jumpTimes = 1;

    public bool CanJumpTwice = false;

    public bool isJumpAble;

    [Header("冲刺参数")]
    /*[HideInInspector]*/ public Vector2 InputDushDirection;

    /*[HideInInspector]*/ public Vector2  currentDushDirection = Vector2.zero;

    public float DushAcceleration;

    [HideInInspector] public float DushTapTime;

    public float DushTime;

    public float DushCD;

    public bool isCatDushAble;

    public bool isDushCollide;

    public bool isAttackAble;

    [Header("攀爬参数")]
    public bool isClimbAble;

    public float ClimbSpeed;

    [HideInInspector] public float speed = 0;

    [HideInInspector] public float timeSpend = 0;

    private float j = 1;

    /*[HideInInspector]*/ public bool isDushAble;

    [HideInInspector] public bool isDush;

    [HideInInspector] public bool isMoveAble;

    public float UnControllTime;

    [Header("飞行参数")]
    public float FlyForce;

    public float FlyDownForce;

    public bool isFlyAble;

    // Start is called before the first frame update
    private PlayerInputController()
    {

    }

    private void Awake()
    {
        Instance = this;
        isMoveAble = true;
        isDushAble = true;
        PlayerInput = new PlayerInput();
        Rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        PhysicsCheck = transform.Find("IsOnGroundChecker").GetComponent<PhysicsCheck>();
        character = GetComponent<Character>();

        PlayerInput.GamePlay.Jump.started += Jump;
        PlayerInput.GamePlay.Jump.canceled += LeaveButton;
        PlayerInput.GamePlay.Dush.started += DushTap;

        PlayerInput.GamePlay.Skill.started += GameEventSystem.instance.UseSkill_1or2;

        GameEventSystem.instance.OnPlayerTakeDamage += BeHurt;
    }

    private void Start()
    {
        Rigidbody2D.drag = 0f;
    }

    private void OnEnable()
    {
        PlayerInput.Enable();
    }

    private void OnDisable()
    {
        PlayerInput.Disable();
    }

    void Update()
    {
        GetMoveDirection();
        GetDushDirection();
        GetisJumpAble();
        TwiceJumpLimit();
    }

    private void FixedUpdate()
    {
        DushControll();
        Dush();
        Move();
        Fly();
        
    }

    private void Move()
    {
        if(isMoveAble)
        {
            if (!isClimbAble)
            {
                if (isLeftOnWall)
                {
                    if (MoveDirection.x < 0)
                    {
                        Rigidbody2D.velocity = new Vector2(0, Rigidbody2D.velocity.y);
                        return;
                    }
                }
                else if (isRightOnWall)
                {
                    if (MoveDirection.x > 0)
                    {
                        Rigidbody2D.velocity = new Vector2(0, Rigidbody2D.velocity.y);
                        return;
                    }
                }
            }

            if (inputDirection.y > 0 && isClimbAble && (isLeftOnWall || isRightOnWall))
            {
                Rigidbody2D.AddForce(-ClimbSpeed * Physics2D.gravity, ForceMode2D.Force);
                Rigidbody2D.velocity = Vector2.up * inputDirection.y;
            }
            //else
            Rigidbody2D.velocity = new Vector2(Speed * MoveDirection.x * Time.deltaTime, Rigidbody2D.velocity.y);
        }

        #region 人物翻转
        if (MoveDirection.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if(MoveDirection.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        #endregion
    }

    public void Fly()
    {
        if(isFlyAble)
        {
            
            Rigidbody2D.AddForce(-0.9f*Physics2D.gravity, ForceMode2D.Force);
            if(inputDirection.y > 0)
            {
                Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x, FlyForce);
            }
            else if(inputDirection.y < 0)
            {
                Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x, -FlyDownForce);
            }

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
            InputDushDirection = PlayerInput.GamePlay.Move.ReadValue<Vector2>().normalized;
        else
        {
            if (spriteRenderer.flipX != true)
            {
                InputDushDirection.x = 1;
                InputDushDirection.y = 0;
            }

            else
            {
                InputDushDirection.x = -1;
                InputDushDirection.y = 0;
            }
        }
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (isJumpAble)
        {
            jumpTimes--;
            if (isClimbAble)
            {
                if (isLeftOnWall)
                {
                    UnMoveForaWhile(0.2f);
                    Rigidbody2D.AddForce(JumpForce * (Vector2.right + Vector2.up), ForceMode2D.Impulse);
                }
                else if (isRightOnWall)
                {
                    UnMoveForaWhile(0.2f);
                    Rigidbody2D.AddForce(JumpForce * (Vector2.left + Vector2.up), ForceMode2D.Impulse);
                }
                else Rigidbody2D.AddForce(JumpForce * transform.up, ForceMode2D.Impulse);
            }
            else Rigidbody2D.AddForce(JumpForce * transform.up, ForceMode2D.Impulse);
        }
    }

    private void LeaveButton(InputAction.CallbackContext context)
    {
        if(Rigidbody2D.velocity.y >= JumpLimitFactor)
            Rigidbody2D.AddForce(JumpForcedown * Vector2.down, ForceMode2D.Impulse);
    }

    private void GetisJumpAble()
    {
        if(Instance.jumpTimes > 0)
            isJumpAble = true;
        else
            isJumpAble = false;
        if (jumpTimes == 2)
        {
            CanJumpTwice = false;
        }
    }

    private void DushTap(InputAction.CallbackContext context)
    {
        
        if (isDushAble||isCatDushAble) 
        {
            isDush = true;
            DushTapTime = Time.time;
            isDushAble = false;
        }

    }
    public void DushTap()
    {
        if (isDushAble)
        {
            isDush = true;
            DushTapTime = Time.time;
            isDushAble = false;
        }

    }

    private void DushControll()
    {
        float CatDushPlusTime = 0;
        if(isCatDushAble)
        {
            CatDushPlusTime = SkillCenter.instance.CatDushPlusTime;
        }//判断是否在技能期间，增加冲刺时间

        if(isDush)
        {
            //这里可以插入镜头抖动事件（
            if(isCatDushAble)
            {
                character.BeInvulnerableEnable();
                isAttackAble = true;
                //这里可以插入镜头抖动事件（猫猫冲刺时
            }

            if (Time.time - DushTapTime >= DushTime + CatDushPlusTime||isDushCollide)
            {
                if (isCatDushAble)
                {
                    isCatDushAble = false;
                    isAttackAble = false;
                    character.BeInvulnerableDisable();
                }

                isDush = false;
            }
        }

        if(!isDushAble)
        {
            if (Time.time - DushTapTime >= DushCD)
            {
                isDushAble = true;
            }
                
        }
    }

    private void Dush()
    {
        if(isDush)
        {
            if (j == 1)
                currentDushDirection = InputDushDirection;
            j++;
            MoveDisable();
            Debug.Log("Dush");
            speed += DushAcceleration * (timeSpend += Time.deltaTime);
            Rigidbody2D.velocity = currentDushDirection * speed; 
            //Rigidbody2D.position += currentDushDirection * speed * Time.deltaTime;
            //Rigidbody2D.AddForce(currentDushDirection * speed, ForceMode2D.Force);
        }
        if (!isDush&&j!=1)
        {
            Rigidbody2D.velocity = Vector2.zero;
            currentDushDirection = Vector2.zero;
            MoveEnable();
            if(isFlyAble) { FlyDisable(); }
            speed = 0;
            timeSpend = 0;
            j = 1;
        }
    }

    public void BeHurt(Transform attacker)
    {
        float knockBack = attacker.GetComponent<Attack>().knockBack;

        Rigidbody2D.velocity = Vector2.zero;
        UnMoveForaWhile(UnControllTime);
        Vector2 dir = new Vector2((transform.position.x - attacker.transform.position.x), (transform.position.y - attacker.transform.position.y)).normalized;
        Rigidbody2D.AddForce(dir * knockBack, ForceMode2D.Impulse);
        
    }

    public void TwiceJumpLimit()
    {
        if(CanJumpTwice&&(jumpTimes == 0))
            JumpTwiceDisable();
    }
    public void JumpTwiceEnable()
    {
        Debug.Log("JumpTwiceEnable");
        CanJumpTwice = true;
    }

    public void JumpTwiceDisable()
    {
        Debug.Log("JumpTwiceDisable");
        CanJumpTwice = false;
    }
    public void ClimbEnable()
    {
        Debug.Log("ClimbEnable");
        isClimbAble = true;
    }

    public void ClimbDisable()
    {
        Debug.Log("ClimbDisable");
        isClimbAble = false;
    }

    public void UnMoveForaWhile(float Time)
    {
        MoveDisable();
        Invoke("MoveEnable", Time);
    }

    public void MoveDisable()
    {
        isMoveAble = false;
    }
    public void MoveEnable()
    {
        isMoveAble = true;
    }
    public void ControllDisable()
    {
        PlayerInput.GamePlay.Disable();
    }
    public void ControllEnable()
    {
        PlayerInput.GamePlay.Enable();
    }
    public void FlyEnable()
    {
        isFlyAble = true;
    }
    public void FlyDisable()
    {
        isFlyAble = false;
    }

    public void CatDushEnable()
    {
        isCatDushAble = true;
    }

    public void CatDushDisable()
    {
        isCatDushAble = false;
    }

    public void DushColliderTrue()
    {
        isDushCollide = true;
    }

    public void DushColliderFlase()
    {
        isDushCollide = false;
    }
}
