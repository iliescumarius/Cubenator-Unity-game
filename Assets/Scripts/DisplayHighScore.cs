using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DisplayHighScore : MonoBehaviour
{
    public Text ScoreToBeat;//highscore
    // Start is called before the first frame update
    void Start()
    {
        ScoreToBeat.text = ScoreToBeat.text + PlayerPrefs.GetInt("highscore").ToString();
        Debug.Log(PlayerPrefs.GetInt("highscore").ToString());
    }


}
