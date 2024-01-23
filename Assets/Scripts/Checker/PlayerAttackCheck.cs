using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackCheck : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Collider2D>().enabled = false;
    }

    public void Update()
    {
        if(PlayerInputController.Instance.isAttackAble) 
        {
            GetComponent<Collider2D>().enabled = true;
        }
        else
        {
            GetComponent<Collider2D>().enabled = false;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Enemy" && other.GetComponent<Character>().isdead != true)
        {
            other.GetComponent<Character>()?.CharacterTakeDamage(transform.parent.GetComponent<PlayerAttack>());
        }
    }
}
