using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhysicsCheck : MonoBehaviour
{
    public bool isOnGround;
    public Canvas canvas;
    public static int jumpTimes=0;
    public bool CanJumpTwice = false;
    // Start is called before the first frame update
    void Start()
    {
        Timer.Instance.Schedule(ShowJumpTimes, null, 0, 0, 5);
    }

    // Update is called once per frame
    void Update()
    {
       
     if(Input.GetKeyDown(KeyCode.Escape))
        {
            canvas.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground")
        {
            isOnGround = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            jumpTimes++;
        }
        
    }
    private void ShowJumpTimes(object a)
    {
        Debug.Log(CanJumpTwice);
        
        if (jumpTimes > 0)
        {
            Debug.Log(jumpTimes);
        }
    }
}
