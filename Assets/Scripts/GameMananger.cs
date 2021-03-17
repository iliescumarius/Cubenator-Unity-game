using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class GameMananger : MonoBehaviour
{
    public bool gameHasEnded = false;
    public static bool ForMonetizationRestartButton = false;
    public static bool ForMonetization = true;//pentru ca sa verificam daca s a terminat jocul si sa alegem rewardul dupa video
    public float restartDelay = 10f;
    public GameObject completeLevelUI;
    private int  levelToUnlock;
    public Text CoinsText;
    public AudioSource coinSound;
    public Button RestartButton;
    public Button ExtraLife;  
    public Text Score;
    [HideInInspector]
    public int Coins = 0;
    [HideInInspector]
    public int MemoryForCoins = 0;
    public static bool Revive = false;
    public static string ScoreBeforeRevive;
    public Button Pause;
    public void EndGame ()
    { if (gameHasEnded == false)
        {
            //Revive = false;
            int x=1;//= Monetization.RandomNumber;
            ForMonetization = false;
            ForMonetizationRestartButton = true;
            Coins = 0;
            MemoryForCoins = 0;
            FreeRideCoin.FreeRideCoins = 0;
            gameHasEnded = true;
            RestartButton.gameObject.SetActive(true);          
            ExtraLife.gameObject.SetActive(true);
            Pause.gameObject.SetActive(false);
            
             // Invoke("Restart", restartDelay);de schimabtttttttttttt     
        }
    }
    
    public void Restart()
    {
        int random=Random.Range(0,3);
        if(random==2)
        {
            Monetization aux = new Monetization();
            aux.ShowInterstitialAd();
        }    
        Revive = false;
        Coins = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ReviveRestart()
    {
        //Revive = false;
        Coins = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void CompleteLevel()
    { Coins = 0;
       completeLevelUI.SetActive(true);
        Debug.Log("LEVEL WON");               
    }
    public void WinLevel()
    {      
       levelToUnlock =SceneManager.GetActiveScene().buildIndex;//ramane asa pentru ca scena pe care suntem cand castigam este deja cea dorita si se da unlock
        PlayerPrefs.SetInt("levelReached", levelToUnlock);       
    }
    public void AdCoin()
    {
        int TotalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
        TotalCoins += 1;
        Coins++;
        PlayerPrefs.SetInt("TotalCoins", TotalCoins);
         CoinsText.text = Coins.ToString("0");
        Debug.Log(TotalCoins.ToString());
    }
    void Update()
    {
        if (FreeRideCoin.FreeRideCoins > MemoryForCoins)
        { 
            if (MemoryForCoins != FreeRideCoin.FreeRideCoins)
                coinSound.Play();
                MemoryForCoins = FreeRideCoin.FreeRideCoins;
                CoinsText.text = MemoryForCoins.ToString();
                int aux = PlayerPrefs.GetInt("TotalCoins");           
                aux += 1;
                PlayerPrefs.SetInt("TotalCoins", aux);           
        }

    }
    public void ReviveButton()
    {
        ScoreBeforeRevive = Score.text;
        Revive = true;
        ReviveRestart();
    }

}
