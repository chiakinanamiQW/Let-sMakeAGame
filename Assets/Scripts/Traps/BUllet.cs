using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BUllet : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
