using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class AttackCheck : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player"&&other.GetComponent<Character>().isdead!=true)
        {
            if (this.transform.parent != null)
                other.GetComponent<Character>()?.TakeDamage(transform.parent.GetComponent<Attack>());
            else
                other.GetComponent<Character>()?.TakeDamage(this.GetComponent<Attack>());

        }
    }
}
