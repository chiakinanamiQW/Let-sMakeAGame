using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int MaxHealth;
    public int CurrentHealth;

    public float invulnerableDuration;

    public bool BeInvulnerable = false;//主动进入无敌状态，结束时间由外部控制
    public bool invulnerable;

    public bool isHurt;

    public bool isdead;

    private float invulnerableCounter;

    private void Awake()
    {
        CurrentHealth = MaxHealth;
        invulnerable = false;
        isdead = false;
        isHurt = false;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (invulnerable)
        {
            invulnerableCounter -= Time.deltaTime;
            if (invulnerableCounter <= 0)
            {
                invulnerable = false;
            }
        }
    }

    public void BeInvulnerableEnable()
    {
        BeInvulnerable = true;
        Debug.Log("BeInvulnerableEnable");
    }

    public void BeInvulnerableDisable()
    {
        BeInvulnerable = false;
    }

    public void TakeDamage(Attack attacker)
    {
        if (invulnerable||BeInvulnerable) { return; }

        if(CurrentHealth - attacker.Damage > 0)
        {
            GameEventSystem.instance.PlayerTakeDamage(attacker.transform);

            CurrentHealth -= attacker.Damage;
            TriggerInvulnerable();
        }
        else
        {
            CurrentHealth = 0;
            GameEventSystem.instance.PlayerDead();
        }
    }

    private void TriggerInvulnerable()
    {
        if (invulnerable != true)
            invulnerable = true;

        invulnerableCounter = invulnerableDuration;
    }
}
