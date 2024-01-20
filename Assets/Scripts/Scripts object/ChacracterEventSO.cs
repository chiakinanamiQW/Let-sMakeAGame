using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(fileName ="Event/CharcterEventSO")]
public class CharacterEventSO : ScriptableObject //SOΪ�˿糡����������   
{
    public UnityAction<Character> OnEventRised;

    public void RaiseEvent(Character character)
    {
        OnEventRised?.Invoke(character);
    }
}
