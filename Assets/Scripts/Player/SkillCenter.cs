using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCenter : MonoBehaviour
{
    public static SkillCenter instance;

    private SkillCenter() { }

    private void Awake()
    {
        instance = this;
        Timer.Instance.Schedule(Dectect,null, 0, 0, 5);
        Debug.Log(Timer.Instance);
    }

    public void CatDush()
    {
        PlayerInputController.Instance.DushTap();
    }
    public void RabitJump()
    {
        PlayerInputController.Instance.JumpTwice();
    }
    private void Dectect(object t)
    {   PlayerInputController p= (PlayerInputController)t;  
        Debug.Log(p);
    }
}
