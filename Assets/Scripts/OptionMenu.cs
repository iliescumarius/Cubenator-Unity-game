using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider SideForceSlider;
   // public Slider VolumeSlider;
    public Text SensivityValue;
   // public Text VolumeValue;
    public void Start()
    {      
        if (PlayerPrefs.GetFloat("SideForce")== 0)
        {
            float aux = 60;
            PlayerPrefs.SetFloat("SideForce",aux);
            SideForceSlider.value = PlayerPrefs.GetFloat("SideForce");
        }
            else
            SideForceSlider.value = PlayerPrefs.GetFloat("SideForce");

    }
    public void Update()
    {
        SensivityValue.text = SideForceSlider.value.ToString()+'%';
       /* if (VolumeSlider.value < 0)
        {
            float aux = 100;
            float aux2= aux + VolumeSlider.value; 
            VolumeValue.text =aux2.ToString() + '%';
        }*/

    }

    public void SetVolume ( float volume)
    {
              
        audioMixer.SetFloat("volume", volume);
      
    }
    public void SetSideSpeed()
    {   
        float SideForce =SideForceSlider.value;
        PlayerPrefs.SetFloat("SideForce",SideForce);
        Debug.Log(PlayerPrefs.GetFloat("SideForce").ToString());
    }

   
}
