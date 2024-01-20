using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public CharacterEventSO healthEvent;
    public HealthManegr H;
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
        H.OnHealthChange(health);
    }
    

}
