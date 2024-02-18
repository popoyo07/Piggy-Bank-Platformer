using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{

    private int money = 0;

    [SerializeField] private Text ScoreText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.CompareTag("Penny"))
        {
            Destroy(collision.gameObject);
            money += 1;
            ScoreText.text =" " + money;
            Debug.Log("Money: " +money);
        }
        else if (collision.gameObject.CompareTag("Nickle"))
        {
            Destroy(collision.gameObject);
            money += 5;
            ScoreText.text = " " + money;
            Debug.Log("Money: " + money);
        }
        else if (collision.gameObject.CompareTag("Dime"))
        {
            Destroy(collision.gameObject);
            money += 10;
            ScoreText.text = " " + money;
            Debug.Log("Money: " + money);
        }
        else if (collision.gameObject.CompareTag("Quarter"))
        {
            Destroy(collision.gameObject);
            money += 25;
            ScoreText.text = " " + money;
            Debug.Log("Money: " + money);
        }
    }
}
