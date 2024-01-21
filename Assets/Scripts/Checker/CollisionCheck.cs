using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    PlayerInputController playerInputController;
    private int i;

    private void Awake()
    {
        playerInputController = transform.parent.GetComponent<PlayerInputController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(playerInputController.isDush&&collision.tag != "Item")
        {
            playerInputController.isDushCollide = true;
        

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag != "Item")
        playerInputController.isDushCollide = false;
    }
}
