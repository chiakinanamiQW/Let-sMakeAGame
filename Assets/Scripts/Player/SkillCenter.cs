using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCenter : MonoBehaviour
{
    public static SkillCenter instance;

    private SkillCenter() { }

    private void Awake()
    {
        instance = this;
    }

    public void CatDush()
    {
        PlayerInputController.Instance.DushTap();
    }
}
