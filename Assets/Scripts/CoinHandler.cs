using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinHandler : MonoBehaviour
{
    [SerializeField] GameObject coin, confetti;
    public Text coinAmount;
    [HideInInspector]
    public static int coinIndex = 0;
    [HideInInspector]
    public static int currentCoinIndex= 0;
    
    void Start()
    {
        confetti.SetActive(false);
        if(PlayerPrefs.HasKey("Gold"))
        {

            coinIndex = PlayerPrefs.GetInt("Gold");
        }
        coinAmount.text = coinIndex.ToString();
    }

    private void Update()
    {
        //Debug.Log(currentCoinIndex);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Friend" || other.gameObject.tag == "Ball")
        {
            coinIndex++;
            currentCoinIndex++;
            PlayerPrefs.SetInt("Gold", coinIndex);
            coinAmount.text = coinIndex.ToString();
            confetti.SetActive(true);
            Destroy(coin);  
        }
    }
}
