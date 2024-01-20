using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelSoul : Soul
{
    protected override void Skill()
    {
        SkillCenter.instance.Squirrelclimb();
        base.Skill();
    }
}
