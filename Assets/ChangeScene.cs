using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("LoadScene", 1f);
            

        }
    }
    private void LoadScene()
    {
        SceneManager.LoadSceneAsync("YouWin"); // Replace "Scene1" with the actual name of your first scene
    }
}
