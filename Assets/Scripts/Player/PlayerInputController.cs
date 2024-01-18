using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    public PlayerInput PlayerInput;

    public Rigidbody2D Rigidbody2D;

    private SpriteRenderer spriteRenderer;

    public float Speed;

    [HideInInspector] public Vector2 MoveDirection;

    private Vector2 inputDirection;

    public bool isMoveAble;
    // Start is called before the first frame update

    private void Awake()
    {
        isMoveAble = true;
        PlayerInput = new PlayerInput();
        Rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
}
