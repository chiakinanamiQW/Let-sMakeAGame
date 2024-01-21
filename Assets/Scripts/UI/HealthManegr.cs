using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManegr : MonoBehaviour
{
    public List<Image> sprites = new List<Image>();
    public Image h1;
    public Image h2;
    public Image h3;


    public void OnHealthChange(int currentHealth)
    {   if (currentHealth == 3)
        {
            h1.gameObject.SetActive(true);
            h2.gameObject.SetActive(true);
            h3.gameObject.SetActive(true);
        }
        if (currentHealth == 2)
        {
            h1.gameObject.SetActive(false);   
            h2.gameObject.SetActive(true) ;
            h3.gameObject.SetActive(true);
            Debug.Log(-1);
        }   
        if (currentHealth == 1)
        {
            h1.gameObject.SetActive(false);
            h2.gameObject.SetActive(false);
            h3.gameObject.SetActive(true);
        }   
        if (currentHealth == 0)
        {
            h1.gameObject.SetActive(false);
            h2.gameObject.SetActive(false);
            h3.gameObject.SetActive(false);
        }
    }
}
