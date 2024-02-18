using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
            ScoreText.text =" $ " + money;
            Debug.Log("Money: " +money);
        }
        else if (collision.gameObject.CompareTag("Nickle"))
        {
            Destroy(collision.gameObject);
            money += 0.05f;
            ScoreText.text = " $ " + money;
            Debug.Log("Money: " + money);
        }
        else if (collision.gameObject.CompareTag("Dime"))
        {
            Destroy(collision.gameObject);
            money += 0.10f;
            ScoreText.text = " $ " + money;
            Debug.Log("Money: " + money);
        }
        else if (collision.gameObject.CompareTag("Quarter"))
        {
            Destroy(collision.gameObject);
            money += 0.25f;
            ScoreText.text = " $ " + money;
            Debug.Log("Money: " + money);
        }
    }
}
