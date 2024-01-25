using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    public Canvas c;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            c.gameObject.SetActive(true);
        }
    }
}
