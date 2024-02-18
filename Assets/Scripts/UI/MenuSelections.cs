using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSelections : MonoBehaviour
{
    void Update()
    {
        // Check for keyboard input
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            LoadScene1();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            LoadScene2();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            QuitGame();
        }
    }
    public void LoadScene1()
    {
        SceneManager.LoadSceneAsync("Level 1"); // Replace "Scene1" with the actual name of your first scene
    }

    public void LoadScene2()
    {
        SceneManager.LoadSceneAsync("Credits"); // Replace "Scene2" with the actual name of your second scene
    }

    void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
