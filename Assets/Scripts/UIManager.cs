using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] public GameObject endScreen, gameOverScreen;
    public Text endScreenCoinText;
    public Text gameOverScreenCoinText;

    void Start()
    {
        endScreen.SetActive(false);
    }

    void Update()
    {
        endScreenCoinText.text = CoinHandler.currentCoinIndex.ToString();
        gameOverScreenCoinText.text = CoinHandler.currentCoinIndex.ToString();
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
