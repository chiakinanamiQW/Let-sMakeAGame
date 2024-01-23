using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class SkillManager : MonoBehaviour
{
    public Image s1;
    public Image s2;
    public Sprite Sprite;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switch (GameEventSystem.instance.a)
            {
                case 1:
                    s1.sprite = Sprite;
                    break;
                case 2:
                    s2.sprite = Sprite;
                    break;
            }
        }
    }
    private void Update()
    {
        if (GameEventSystem.instance._1SkillUse)
        {
            s1.sprite = null;
            GameEventSystem.instance._1SkillUse=false;
        }
        if (GameEventSystem.instance._2SkillUse) 
        {
            s2.sprite = null; GameEventSystem.instance._2SkillUse=false;    
        }
    }

}
