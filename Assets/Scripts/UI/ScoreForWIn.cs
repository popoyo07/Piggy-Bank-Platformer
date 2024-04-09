using UnityEngine;
using UnityEngine.UI;

public class ScoreForWin : MonoBehaviour
{
    [SerializeField] private Text ScoreText;

    private void Start()
    {
        // Retrieve collected money from PlayerPrefs
        float money = PlayerPrefs.GetFloat("PlayerMoney", 0f);

        // Display collected money as points
        ScoreText.text = "$" + money.ToString("F2");
    }
}
