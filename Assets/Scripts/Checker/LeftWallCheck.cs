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
