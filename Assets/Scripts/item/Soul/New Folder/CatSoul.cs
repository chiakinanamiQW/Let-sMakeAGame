using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSoul : Soul
{
    protected override void Skill()
    {
        Debug.Log(1);
        SkillCenter.instance.CatDush();
        
        base.Skill();
    }
    
}
