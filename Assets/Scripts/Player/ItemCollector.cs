using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{

    private float money = 0f;

    [SerializeField] private Text ScoreText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Penny"))
        {
            Destroy(collision.gameObject);
            money += 0.01f;
        }
        else if (collision.gameObject.CompareTag("Nickle"))
        {
            Destroy(collision.gameObject);
            money += 0.05f;
        }
        else if (collision.gameObject.CompareTag("Dime"))
        {
            Destroy(collision.gameObject);
            money += 0.10f;
        }
        else if (collision.gameObject.CompareTag("Quarter"))
        {
            Destroy(collision.gameObject);
            money += 0.25f;
        }

        if (money >= 5f)
        {
            Invoke("LoadScene", 1f);
            ; // Replace "Scene1" with the actual name of your first scene
        }

        // Format the money with two decimal places and update the UI text
        ScoreText.text = " $ " + money.ToString("F2");

        // Log the formatted money value
        Debug.Log("Money: " + money.ToString("F2"));
    }

    private void LoadScene()
    {
        SceneManager.LoadSceneAsync("YouWin"); // Replace "Scene1" with the actual name of your first scene
    }
}

