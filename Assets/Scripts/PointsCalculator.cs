using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class PointsCalculator : MonoBehaviour
{
    [SerializeField] GameObject ball;
    public TextMeshPro pointsAmountText;
    string pointsAmountString;

    [SerializeField] UIManager uIManager;
    void Start()
    {
        
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ball")
        {
            pointsAmountString = pointsAmountText.text;
            Debug.Log("Points:" + " " + pointsAmountString);

            switch(pointsAmountString)
            {
                case "5x":
                    CoinHandler.currentCoinIndex *= 5;
                    Debug.Log(CoinHandler.currentCoinIndex);
                    uIManager.endScreen.SetActive(true);
                    Time.timeScale = 0;
                    //Destroy(ball);
                    break;
                case "4x":
                    CoinHandler.currentCoinIndex *= 4;
                    Debug.Log(CoinHandler.currentCoinIndex);
                    uIManager.endScreen.SetActive(true);
                    Time.timeScale = 0;
                    //Destroy(ball);
                    break;
                case "3x":
                    CoinHandler.currentCoinIndex *= 3;
                    Debug.Log(CoinHandler.currentCoinIndex);
                    uIManager.endScreen.SetActive(true);
                    Time.timeScale = 0;
                    //Destroy(ball);
                    break;
                case "2x":
                    CoinHandler.currentCoinIndex *= 2;
                    Debug.Log(CoinHandler.currentCoinIndex);
                    uIManager.endScreen.SetActive(true);
                    Time.timeScale = 0;
                    //Destroy(ball);
                    break;
                case "1x":
                    uIManager.endScreen.SetActive(true);
                    Time.timeScale = 0;
                    //Destroy(ball);
                    break;
            }
        }
    }
}
