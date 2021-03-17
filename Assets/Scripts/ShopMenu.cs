using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
//using UnityEditor.Experimental.GraphView;
using UnityEngine.SceneManagement;

public class ShopMenu : MonoBehaviour
{
    public Text CoinBalance;
    public Button[] Skins;// variabile in care tinem minte buttonul care acceseaza skinul
    public Text[]   Price;//pretul skinului
    public PlayerPrefsValue[] SkinsStatus;//tipul de variabila in care tinem minte daca este unlock skinul si numele acestuia 
    public Sprite[] ToChangePhoto;
    public Image CurrentSkin;
    [HideInInspector]
    public int AvailableCoins;//totalul de coinuri pe care il avem
    [HideInInspector]
    public string NameOfSkin;//retinem numele butonului care este apasat;
    // Start is called before the first frame update
    void Start()
    { 
        Debug.Log(PlayerPrefs.GetInt(Skins[1].name, SkinsStatus[1].Unlocked));
        CoinBalance.text = PlayerPrefs.GetInt("TotalCoins").ToString();
        AvailableCoins = int.Parse(CoinBalance.text);
        CurrentSkin.sprite = ToChangePhoto[PlayerPrefs.GetInt("ChosenSkin")];
       for (int i = 0; i < Skins.Length; i++)
        {
            int unlocked=PlayerPrefs.GetInt(Skins[i].name,SkinsStatus[i].Unlocked);
            if (unlocked == 0)
            {              
                if (AvailableCoins <= int.Parse(Price[i].text))
                    Skins[i].interactable = false;
            }
            else  if (unlocked == 1)
            {
                  
                Skins[i].image.GetComponent<Image>().sprite = ToChangePhoto[i];
                Price[i].text = "";
            }
        }      
    }
    
    public void PressedButton()
    {
        CoinBalance.text = PlayerPrefs.GetInt("TotalCoins").ToString();
        AvailableCoins = int.Parse(CoinBalance.text);
        NameOfSkin = EventSystem.current.currentSelectedGameObject.name;
        PlayerPrefs.SetInt("ChosenSkin", 0);//0 este skinul basic;
        for (int i = 0; i < Skins.Length; i++)
        { 
            int unlocked = PlayerPrefs.GetInt(Skins[i].name, SkinsStatus[i].Unlocked);
            if (Skins[i].name == NameOfSkin)
            {
                if (unlocked == 0)
                {
                    Debug.Log("sad");
                    AvailableCoins -= int.Parse(Price[i].text);
                    PlayerPrefs.SetInt("TotalCoins", AvailableCoins);
                    SkinsStatus[i].Unlocked = 1;
                    PlayerPrefs.SetInt(Skins[i].name, SkinsStatus[i].Unlocked);
                    Skins[i].image.GetComponent<Image>().sprite = ToChangePhoto[i];
                    CoinBalance.text = PlayerPrefs.GetInt("TotalCoins").ToString();
                }
                else
                {
                    PlayerPrefs.SetInt("ChosenSkin",i);
                    CurrentSkin.sprite = ToChangePhoto[i];
                   // Debug.Log(PlayerPrefs.GetInt("ChosenSkin", i));
                    //apelam functia de selectare a skinului
                }                    
            }
        }
    }
   
}
[System.Serializable]
public class PlayerPrefsValue
{
    public int Unlocked = 0;//1=available 0=locked
}
