using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManegr : MonoBehaviour
{
    public SpriteRenderer h1;
    public SpriteRenderer h2;
    public SpriteRenderer h3;


    public void OnHealthChange(int currentHealth)
    {
        if (currentHealth == 2)
        {
            h1.gameObject.SetActive(false);
        }
        if (currentHealth == 1)
        {
            h2.gameObject.SetActive(false);
        }
        if (currentHealth == 0)
        {
            h3.gameObject.SetActive(false);
        }
    }
}
