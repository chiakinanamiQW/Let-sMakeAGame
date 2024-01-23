using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    [Header("基本参数")]
    public float Speed;
    private float currentSpeed;

    public float StopTime;

    [Header("停留点")]
    public bool isStandbyPointLeft;
    public bool isStandbyPointRight;
    public bool isStop;


    public Vector2 StandbyPointLeft;
    public Vector2 StandbyPointRight;
    public float StandbyPointRadius;

    private Vector2 position;

    private Rigidbody2D Rigidbody2D;

    private SpriteRenderer spriteRenderer;

    private Character character;

    private int i = 0;
    private void Awake()
    {
        currentSpeed = Speed;
        Rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        character = GetComponent<Character>();
    }
    void Start()
    {
        position = transform.position;
    }

    void Update()
    {
        GetisStandbyPointLorR();
        enemyDead();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(position + StandbyPointLeft, StandbyPointRadius);
        Gizmos.DrawWireSphere(position + StandbyPointRight, StandbyPointRadius);
    }

    private void Move()
    {
        if(isStop)
        {
            Rigidbody2D.velocity = new Vector2(0, Rigidbody2D.velocity.y);
            return;
        }

        if (isStandbyPointLeft)
        {
            StartCoroutine(Stop());
            spriteRenderer.flipX = true;
            currentSpeed = Speed;

        }
        else if (isStandbyPointRight)
        {
            StartCoroutine(Stop());
            spriteRenderer.flipX = false;
            currentSpeed = -Speed;
        }
        Rigidbody2D.velocity = new Vector2(currentSpeed, Rigidbody2D.velocity.y);

    }

    private void GetisStandbyPointLorR()
    {
        if (Physics2D.OverlapCircle(position + StandbyPointLeft, StandbyPointRadius, 9))
        {
            isStandbyPointLeft = true;
        }
        else
        {
            isStandbyPointLeft = false;
        }

        if (Physics2D.OverlapCircle(position + StandbyPointRight, StandbyPointRadius, 9))
        {
            isStandbyPointRight = true;
        }
        else
        {
            isStandbyPointRight = false;
        }
    }

    IEnumerator Stop()
    {
        yield return new WaitForSeconds(0.1f);
        isStop = true;
        yield return new WaitForSeconds(StopTime);
        isStop = false;
    }

    private void enemyDead()
    {
        if(character.isdead) 
        {
            Speed = 0;
            Debug.Log("Enemy Dead");
            Destroy(gameObject);
        }
    }
}
