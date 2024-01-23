using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : Item
{
    private int a;

    protected virtual void Skill()
    {

    }
   

    protected override void itemBePick(Collider2D collision)
    {
        a = GameEventSystem.instance.GetSkill_1or2();
        if (a == 0)
        {
            GameEventSystem.instance.SkillPickFall();
            return;
        }
            
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

        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        Debug.Log("IsPick");
    }
}
