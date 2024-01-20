using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(fileName ="Event/CharcterEventSO")]
public class CharacterEventSO : ScriptableObject //SO为了跨场景调用数据   
{
    public UnityAction<Character> OnEventRised;

    public void RaiseEvent(Character character)
    {
        OnEventRised?.Invoke(character);
    }
}
