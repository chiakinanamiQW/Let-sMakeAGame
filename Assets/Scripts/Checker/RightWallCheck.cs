using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightWallCheck : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            Debug.Log("RightWall");
            PlayerInputController.Instance.isRightOnWall = true;
            if (PlayerInputController.Instance.isClimbAble)
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
            Debug.Log("RightWall Leave");
            PlayerInputController.Instance.isRightOnWall = false;
        }
    }
}
