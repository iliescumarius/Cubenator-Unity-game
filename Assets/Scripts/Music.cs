using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    private static readonly string FirstPlay = "FirtstPlay";
    private static readonly string MusicPref = "MusicPref";
    private int firstPlayInt;
    public Slider MusicSlider;
    private float MusicFloat;
    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);
        if(firstPlayInt==0)
        {          
            MusicFloat = 0f;
            MusicSlider.value = MusicFloat;
            PlayerPrefs.SetFloat(MusicPref,MusicFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
            
        }
        else
        {
            MusicFloat = PlayerPrefs.GetFloat(MusicPref);          
            MusicSlider.value = MusicFloat;
        }
    }
       public void SaveSoundSetting()
       {
           PlayerPrefs.SetFloat(MusicPref, MusicSlider.value);   
       }

    private void Awake()
    {
     
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Music");
        if (objects.Length > 1)
            Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);

    }
}
