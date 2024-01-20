using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartUI : MonoBehaviour
{
    public Image h1;
    public Image h2;
    public Image h3;
    public CharacterEventSO healthEvent;

    private void OnEnable()
    {
        healthEvent.OnEventRised += OnHealthEvent;
    }
    private void OnDisable()
    {
        healthEvent.OnEventRised -= OnHealthEvent;
    }
    private void OnHealthEvent(Character arg0)
    {
        var health = arg0.CurrentHealth;
        OnHealthChange(health);
    }
    public void OnHealthChange(int currentHealth)
    {
        if(currentHealth == 2)
        {
            h1.gameObject.SetActive(false);
        }
        if(currentHealth == 1)
        {
            h2.gameObject.SetActive(false);
        }
        if (currentHealth == 0)
        {
            h3.gameObject.SetActive(false);
        }
    }
    
}
