using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitSoul : Soul
{
    protected override void Skill()
    {
        SkillCenter.instance.RabitJump();
        base.Skill();
    }
}
