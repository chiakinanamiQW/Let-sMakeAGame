using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSoul : Soul
{
    protected override void Skill()
    {
        SkillCenter.instance.BirdFly();
        base.Skill();
    }
}
