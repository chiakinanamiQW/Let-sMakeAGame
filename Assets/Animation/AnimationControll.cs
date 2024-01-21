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
        animator.SetBool("isDush", PlayerInputController.Instance.isDush);
        if(PlayerInputController.Instance.isFlyAble) 
        {
            animator.SetBool("isOnGround", PhysicsCheck.instance.isOnGround);
        }
        Cat();
        Bird();
        Rabbit();
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
}
