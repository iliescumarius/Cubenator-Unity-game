 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public GameObject CoinR;
    public GameMananger gameManager;
    public AudioSource coinSound;
    [HideInInspector]
    public int Coins = 0;
    public Text CoinsText;

    void Update()
    {
        CoinR.transform.Rotate(0, 0, 90 * Time.deltaTime);
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name=="PlayerCharacter 1")
        {
            coinSound.Play();
            Destroy(gameObject);
           gameManager.AdCoin();
          
            

        }

    }
    /*public void AdCoin()
    {
        int TotalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
        TotalCoins += 1;
        Coins++;
        PlayerPrefs.SetInt("TotalCoins", TotalCoins);
        CoinsText.text = Coins.ToString("0");
        Debug.Log(TotalCoins.ToString());

    }*/


}
