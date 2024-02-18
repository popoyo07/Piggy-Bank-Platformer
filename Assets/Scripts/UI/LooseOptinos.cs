using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LooseOptinos : MonoBehaviour
{
    void Update()
    {
        // Check for keyboard input
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            LoadScene1();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha2))
        {
            QuitGame();
        }
    }
    public void LoadScene1()
    {
        SceneManager.LoadSceneAsync("Main Menu"); // Replace "Scene1" with the actual name of your first scene
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
