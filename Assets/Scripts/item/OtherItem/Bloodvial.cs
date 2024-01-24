using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloodvial : Item
{
    public int RecoverHealth;
    protected override void itemBePick(Collider2D collision)
    {
        collision.GetComponent<Character>()?.ChangCurrentHealth(RecoverHealth);
        base.itemBePick(collision);
    }
}
