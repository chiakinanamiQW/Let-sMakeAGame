using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int Damage;

    public float knockBack;

    public PlayerAttackCheck PlayerattackCheck;

    public Character character;

    private void Awake()
    {
        PlayerattackCheck = transform.Find("PlayerAttackChecker")?.GetComponent<PlayerAttackCheck>();
    } 
}
