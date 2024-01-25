using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartConversation : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "StoryPoint")
        {
            Debug.Log(1);
            collision.gameObject.GetComponent<Conversation>().Speek = true;
        }
    }
    
}
