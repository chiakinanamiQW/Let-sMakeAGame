using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Target : MonoBehaviour
{
    private void Update()
    {
       // Debug.Log(SceneManager.GetActiveScene().name);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(SceneManager.GetActiveScene().name);
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log(SceneManager.GetActiveScene().name);
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex + 1);
            SceneManager.LoadScene("Total");
        }
    }
}
