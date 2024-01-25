using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNext : MonoBehaviour
{
    
   private void Update()
   {
        if (Input.GetKeyDown(KeyCode.K))
        {
            SceneManager.LoadScene(2);
            
        }    
   }
}
