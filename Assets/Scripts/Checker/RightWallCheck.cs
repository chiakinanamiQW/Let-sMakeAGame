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
