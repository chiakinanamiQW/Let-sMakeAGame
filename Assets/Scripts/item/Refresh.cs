using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refresh : MonoBehaviour
{
    // Start is called before the first frame update
    public float RefreshTime = 5;

    IEnumerator RefreshSoul ()
    {
        yield return new WaitForSeconds(RefreshTime);
            GetComponent<Renderer>().enabled = true;
            GetComponent<Collider2D>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
            
            if (GetComponent<Renderer>().enabled == false && GetComponent<Collider2D>().enabled == false)
                StartCoroutine(RefreshSoul());
        
    }
}
