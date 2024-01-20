using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSoul : Soul
{
    protected override void Skill()
    {
        SkillCenter.instance.CatDush();
        base.Skill();
    }
}
