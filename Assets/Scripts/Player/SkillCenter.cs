using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCenter : MonoBehaviour
{
    public static SkillCenter instance;

    private float SquirrelclimbDuration;
    public float CatDushFactor;

    private SkillCenter() { }

    private void Awake()
    {
        instance = this; 
    }

    public void CatDush()
    {
        PlayerInputController.Instance.isDush = true;
        PlayerInputController.Instance.DushTapTime = Time.time;
        PlayerInputController.Instance.isDushAble = false;
    }
    public void RabitJump()
    {
        PlayerInputController.Instance.JumpTwiceEnable();
        PlayerInputController.Instance.jumpTimes++;
    }

    
    public void Squirrelclimb()
    {
        PlayerInputController.Instance.ClimbEnable();
    }

    public void BirdFly()
    {
        PlayerInputController.Instance.BirdFly();
    }
}
