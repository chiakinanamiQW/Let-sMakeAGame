using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refresh : MonoBehaviour
{
    public float RefreshTime;

    
    void Update()
    {
        if (GetComponent<Renderer>().enabled == false && GetComponent<Collider2D>().enabled == false)
            Invoke("refresh", RefreshTime);
    }
    private void refresh()
    {
        
            GetComponent<Renderer>().enabled = true;
            GetComponent<Collider2D>().enabled = true;
        
    }
}
