using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(PlayerInputController.Instance.isDush&&collision.tag != "Item")
        {
            PlayerInputController.Instance.DushColliderTrue();
            StartCoroutine(isDushCollide());

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag != "Item")
            PlayerInputController.Instance.DushColliderFlase();
    }

    IEnumerator isDushCollide()
    {
        yield return new WaitForSeconds(0.1f);
        PlayerInputController.Instance.DushColliderFlase();
    }
}
