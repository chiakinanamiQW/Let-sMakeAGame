using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class SkillManager : MonoBehaviour
{
    public Image s1;
    public Image s2;
    public Sprite sprite;
    private int a;
    private int b;
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {   a=GameEventSystem.instance.GetSkill_1or2();
        if (collision.gameObject.tag == "Player")
        {
            switch (a)
            {
                case 1:
                    s1.sprite = sprite;b = 1; break;
                case 2:
                    s2.sprite = sprite;b = 2; break;
            }
        }
    }
    private void Update()
    {
        Debug.Log(PlayerInputController.Instance.isFlyAble);
        
        if (b == 1)
        {
            if (!PlayerInputController.Instance.isCatDushAble)
            {
                s1.sprite = null;
            }
            if (!PlayerInputController.Instance.isFlyAble)
            {
                s1.sprite = null;
            }
            if (!PlayerInputController.Instance.isClimbAble)
            {
                s1.sprite = null;
            }
            if (!PlayerInputController.Instance.CanJumpTwice)
            {
                s1.sprite = null;
            }
        }
        else if (b == 2)
        {
            if (!PlayerInputController.Instance.isCatDushAble)
            {
                s2.sprite = null;
            }
            if (!PlayerInputController.Instance.isFlyAble)
            {
                s2.sprite = null;
            }
            if (!PlayerInputController.Instance.isClimbAble)
            {
                s2.sprite = null;
            }
            if (!PlayerInputController.Instance.CanJumpTwice)
            {
                s2.sprite = null;
            }
        }
    }
}
