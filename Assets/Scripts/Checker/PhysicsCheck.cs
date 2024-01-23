using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhysicsCheck : MonoBehaviour
{
    public static PhysicsCheck instance;
    public bool isOnGround;
    public bool isOnWall;
    public Canvas canvas;
    private bool isJump=true;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            canvas.gameObject.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Space)&&isJump)
        {

            isJump = false;
        }

        isJump = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ground" || (collision.tag == "Wall"&&PlayerInputController.Instance.isClimbAble))
        {
            if (PlayerInputController.Instance.CanJumpTwice)
            {
                isOnGround = true;
                PlayerInputController.Instance.jumpTimes = 2;
            }
            else
            {
                isOnGround = true;
                PlayerInputController.Instance.jumpTimes = 1;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground"|| (collision.tag == "Wall" && PlayerInputController.Instance.isClimbAble))
        {
            isOnGround = false;
            PlayerInputController.Instance.jumpTimes = 0;
        }
    }
}
