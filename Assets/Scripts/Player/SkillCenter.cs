using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
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

    IEnumerator CatDushCD()
    {
        yield return new WaitForSeconds(CatDushDuration);
        PlayerInputController.Instance.CatDushDisable();
    }

    public static SkillCenter instance;

    public float BridFlyDuration;

    public float RabbitJumpDuration;

    public float SquirrelclimbDuration;

    public float CatDushDuration;

    public float CatDushPlusTime;//puls


    private SkillCenter() { }

    
    private void Awake()
    {
        instance = this; 
    }

    public void CatDush()
    {
        Debug.Log("CatDush");
        PlayerInputController.Instance.CatDushEnable();
        StartCoroutine(CatDushCD());

    }
    public void RabitJump()
    {
        Debug.Log("RabbitJump");
        PlayerInputController.Instance.JumpTwiceEnable();
        PlayerInputController.Instance.jumpTimes++;
        StartCoroutine(RabbitJumpCD());

    }

    
    public void Squirrelclimb()
    {
        Debug.Log("Squirrelclimb");
        PlayerInputController.Instance.ClimbEnable();
        StartCoroutine(ClimbCD());

    }

    public void BirdFly()
    {
        Debug.Log("BirdFly");
        PlayerInputController.Instance.FlyEnable();
        StartCoroutine(FlyCD());

}
}
