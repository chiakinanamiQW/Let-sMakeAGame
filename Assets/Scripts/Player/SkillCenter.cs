using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCenter : MonoBehaviour
{
    IEnumerator RabbitJumpCD()
    {
        yield return new WaitForSeconds(RabbitJumpDuration);
        PlayerInputController.Instance.JumpTwiceDisable();
    }
    IEnumerator FlyCD()
    {
        yield return new WaitForSeconds(BridFlyDuration);
        PlayerInputController.Instance.FlyDisable();
    }
    IEnumerator ClimbCD()
    {
        yield return new WaitForSeconds(SquirrelclimbDuration);
        PlayerInputController.Instance.ClimbDisable();
    }

    public static SkillCenter instance;

    public float BridFlyDuration;
    public float RabbitJumpDuration;
    private float SquirrelclimbDuration;
    public float CatDushFactor;//puls


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
        StartCoroutine(RabbitJumpCD());
    }

    
    public void Squirrelclimb()
    {
        PlayerInputController.Instance.ClimbEnable();
        StartCoroutine(ClimbCD());
    }

    public void BirdFly()
    {
        PlayerInputController.Instance.FlyEnable();
        StartCoroutine(FlyCD());
    }
}
