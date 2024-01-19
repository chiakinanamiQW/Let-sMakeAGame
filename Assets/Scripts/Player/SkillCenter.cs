using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCenter : MonoBehaviour
{
    public static SkillCenter instance;

    private float SquirrelclimbDuration;

    private SkillCenter() { }

    private void Awake()
    {
        instance = this; 
    }

    public void CatDush()
    {
        PlayerInputController.Instance.DushTap();
    }
    public void RabitJump()
    {
        PlayerInputController.Instance.JumpTwice();
    }
    
    public void Squirrelclimb()
    {
        PlayerInputController.Instance.ClimbEnable();
    }
}
