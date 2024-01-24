using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushRoom : MonoBehaviour
{
    public float Jumpforce;
    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * Jumpforce, ForceMode2D.Impulse);
            transform.position=Vector2.MoveTowards(transform.position,new Vector2(transform.position.x,transform.position.y+3),0.2f);
            AudioManager.instance.PlaySFx("Mushroom");
        }
    }
    private void OnCollisionExit2D(UnityEngine.Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, transform.position.y - 3), 0.2f);
        }
    }
}
