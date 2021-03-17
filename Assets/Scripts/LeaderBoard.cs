using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour
{
    const string privateCode = "iUhw8nmyqEWx0mlZi_EKqwJthfKaR3YUeSCli_uy7Sjg";
    const string publicCode = "5eb5706c0cf2aa0c28049439";
    const string webURL = "http://dreamlo.com/lb/";
    public Highscore[] highscoreList;
    DisplayHighscores highscoresDisplay;
    public Scrollbar scrollbar;

    public Text MyUsername;
    public InputField usernameInput;
    public Button SaveUsername;
    [HideInInspector]
    public string usernamepref;
    [HideInInspector]
    public bool ShowUsername=false;//this bool it's usefull when we hit save button and i dont want to add username more then one time above leaderboard

    public void saveUsername()
    {
        PlayerPrefs.GetInt("usernamechosen", 0);
        usernamepref = usernameInput.text;
        PlayerPrefs.SetString("username", usernamepref);
        PlayerPrefs.SetInt("usernamechosen", 1);
        AddNewHighscore(PlayerPrefs.GetString("username"), PlayerPrefs.GetInt("highscore"));
        DownLoadHighscores();
        if (ShowUsername == false)
        { 
            MyUsername.text += " " + usernamepref;
            ShowUsername = true;
        }
        
    }
    private void Start()
    {
        MyUsername.text += " " + PlayerPrefs.GetString("username");
        print(PlayerPrefs.GetInt("usernamechosen"));
        usernameInput.characterLimit = 12;

        if (PlayerPrefs.GetInt("usernamechosen")==1)
        {
            usernameInput.placeholder.GetComponent<Text>().text = "Username already chosen";             
            SaveUsername.enabled=false;
            usernameInput.enabled=false;
        }       
        scrollbar.value = 1.0f;
    }
    private void Awake()
    {     
        //print(PlayerPrefs.GetString("username")+"Awake");
        highscoresDisplay = GetComponent<DisplayHighscores>();

        PlayerPrefs.GetInt("HighscoreMemory", 0);
        if (PlayerPrefs.GetInt("HighscoreMemory") <= PlayerPrefs.GetInt("highscore"))
        {
            int highsc = PlayerPrefs.GetInt("highscore");
            PlayerPrefs.SetInt("HighscoreMemory", highsc);
            AddNewHighscore(PlayerPrefs.GetString("username"), highsc);
            print(PlayerPrefs.GetString("username")+"asdf");
        }
        //Debug.Log(PlayerPrefs.GetInt("HighscoreMemory"));
      
    }
    IEnumerator UploadNewHighscore( string username, int score)
    {
        WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            print("Upload Succcessful");
            DownLoadHighscores();
        }
        else
            print("Error uploading" + www.error);
    }
   
    IEnumerator DownloadHighScoreFromDatabase()
    {
        WWW www = new WWW(webURL + publicCode + "/pipe/");
        yield return www;
        if (string.IsNullOrEmpty(www.error))
        {
            FormatHighscores(www.text);
            highscoresDisplay.OnHighscoresDownloaded(highscoreList);
        }
        else
            print("Error downloading" + www.error);
    }

    public  void AddNewHighscore(string username, int score)
    {
        StartCoroutine(UploadNewHighscore(username, score));
    }

    public void DownLoadHighscores()
    {
        StartCoroutine("DownloadHighScoreFromDatabase");
    }

    void FormatHighscores(string textStream)
    {
        string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        highscoreList = new Highscore[entries.Length];

        for(int i=0;i<entries.Length;i++)
        {
            string[] entryInfo = entries[i].Split(new char[] { '|' });
            string username = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            highscoreList[i] = new Highscore(username,score);
            print(highscoreList[i].username + ": " + highscoreList[i].score);
        }


    }
}
public struct Highscore
{
    public string username;
    public int score;
    public Highscore(string _username, int _score)
    {
        username = _username;
        score = _score;
    }
}
