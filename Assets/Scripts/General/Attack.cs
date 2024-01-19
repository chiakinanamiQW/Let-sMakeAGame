using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int Damage;

    public float knockBack;

    public AttackCheck attackCheck;

    public Character character;

    private void Awake()
    {
        attackCheck = transform.Find("AttackChecker")?.GetComponent<AttackCheck>();
    }
}
