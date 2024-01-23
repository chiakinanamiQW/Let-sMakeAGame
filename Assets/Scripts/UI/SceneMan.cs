using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneMan : MonoBehaviour
{
    public Animator transition;
    public Canvas c;
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    public void ClickNext()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex+1);
    }
    public void ClickOut(Canvas canvas)
    {
        SceneManager.LoadScene("Menu");
        Destroy(canvas);
    }
    public void ToggleFullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
    public void SetResolution(int width, int height, bool fullScreen)
    {
        Screen.SetResolution(width, height, fullScreen);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Continue()
    {
        Time.timeScale = 1.0f;
    }
    public void LoadNextLevel(int TargetIndex)
    {
        SceneManager.LoadScene(TargetIndex);
    }
    
}
