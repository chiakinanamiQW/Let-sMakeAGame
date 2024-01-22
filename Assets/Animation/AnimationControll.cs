using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControll : MonoBehaviour
{
    public Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("VelocityX", Mathf.Abs(PlayerInputController.Instance.Rigidbody2D.velocity.x));
        animator.SetFloat("VelocityY", Mathf.Abs(PlayerInputController.Instance.Rigidbody2D.velocity.y));
        animator.SetBool("isDush", PlayerInputController.Instance.isDush);
        if(PlayerInputController.Instance.isFlyAble) 
        {
            animator.SetBool("isOnGround", PhysicsCheck.instance.isOnGround);
        }
        isClimb();

        Cat();
        Bird();
        Rabbit();
        Squirrel();
    }

    private void Cat()
    {
        if (PlayerInputController.Instance.isCatDushAble)
            animator.SetLayerWeight(1, 0.51f);
        else if(PlayerInputController.Instance.isCatDushAble == false)
            animator.SetLayerWeight(1, 0);
    }

    private void Bird()
    {
        if (PlayerInputController.Instance.isFlyAble)
            animator.SetLayerWeight(2,0.51f);
        else if(PlayerInputController.Instance.isFlyAble == false)
            animator.SetLayerWeight(2, 0);
    }

    private void Rabbit()
    {
        if(PlayerInputController.Instance.CanJumpTwice) 
        {
            animator.SetLayerWeight(3, 0.51f);
        }
        else if(PlayerInputController.Instance.CanJumpTwice == false)
        {
            animator.SetLayerWeight(3, 0);
        }
    }

    private void Squirrel()
    {
        if (PlayerInputController.Instance.isClimbAble)
        {
            animator.SetLayerWeight(4, 0.51f);
        }
        else if (PlayerInputController.Instance.isClimbAble == false)
        {
            animator.SetLayerWeight(4, 0);
        }
    }
    private void isClimb()
    {
        
        if (PlayerInputController.Instance.inputDirection.y > 0 && PlayerInputController.Instance.isClimbAble && (PlayerInputController.Instance.isLeftOnWall || PlayerInputController.Instance.isRightOnWall))
        {
            animator.SetBool("isClimb",true);
        }
        else
        {
            animator.SetBool("isClimb", false);
        }
    }
}