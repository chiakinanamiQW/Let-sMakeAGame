using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : Item
{
    private int a;

    protected virtual void Skill()
    {

    }
   

    protected override void itemBePick()
    {
        a = GameEventSystem.instance.GetSkill_1or2();
        if (a == 0)
            GameEventSystem.instance.SkillPickFall();
        else if (a == 1)
        {
            GameEventSystem.instance.OnSkill1Use += Skill;
            GameEventSystem.instance.SkillPickAchieve();
        }

        else if(a == 2)
        {
            GameEventSystem.instance.OnSkill2Use += Skill;
            GameEventSystem.instance.SkillPickAchieve();
        }
        base.itemBePick();
    }
}
