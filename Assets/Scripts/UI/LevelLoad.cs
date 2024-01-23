using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelLoad : MonoBehaviour
{
    public Animator transition;
    public Canvas c;
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex+1));
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        //play
        c.gameObject.SetActive(true);
        transition.SetTrigger("Start");
        //wait
        yield return new WaitForSeconds(1);
        //load
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(levelIndex-1);
    }
}
