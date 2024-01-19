using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftWallCheck : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Wall")
        {
            Debug.Log("LeftWall");
            PlayerInputController.Instance.isLeftOnWall = true;
            if(PlayerInputController.Instance.isClimbAble)
            {
                if (PlayerInputController.Instance.CanJumpTwice)
                {
                    PhysicsCheck.instance.isOnGround = true;
                    PlayerInputController.Instance.jumpTimes = 2;
                }
                else
                {
                    PhysicsCheck.instance.isOnGround = true;
                    PlayerInputController.Instance.jumpTimes = 1;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            Debug.Log("LeftWall Leave");
            PlayerInputController.Instance.isLeftOnWall = false;
        }
    }
}
