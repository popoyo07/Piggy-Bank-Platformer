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

            Debug.Log("Coliding coliding coliding coliding colliding colliding colliding colliding");
            // Find the GameObject with the ItemCollector script
            GameObject itemCollectorObj = GameObject.FindWithTag("ItemCollector");
            if (itemCollectorObj != null)
            {
                // Get the ItemCollector script component
                ItemCollector itemCollector = itemCollectorObj.GetComponent<ItemCollector>();
                if (itemCollector != null)
                {
                    // Retrieve the money value from the ItemCollector script
                    float money = itemCollector.GetMoney();

                    // Save collected money to PlayerPrefs
                    PlayerPrefs.SetFloat("PlayerMoney", money);
                }
                Invoke("LoadScene", 0.5f);


            }
        }
    }
    private void LoadScene()
    {


            SceneManager.LoadSceneAsync("YouWin"); // Replace "Scene1" with the actual name of your first scene
       
    }
}
