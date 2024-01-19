using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhysicsCheck : MonoBehaviour
{
    public bool isOnGround;
    public Canvas canvas;
    public static int jumpTimes=1;
    public bool CanJumpTwice = false;
    private bool isJump=true;
    // Start is called before the first frame update
    void Start()
    {

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
            jumpTimes--;
            isJump = false;
        }
        isJump = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground" && CanJumpTwice)
        {
            isOnGround = true;
            jumpTimes = 3;
        }
        else if (collision.tag == "Ground")
        {
            isOnGround = true;
            jumpTimes = 1;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Ground")
        {
            isOnGround = false;
        }
    }
}
