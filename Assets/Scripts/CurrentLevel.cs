using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CurrentLevel : MonoBehaviour
{
    public Text CurrentLevelName;
   
    void Update()
     {
        CurrentLevelName.text = SceneManager.GetActiveScene().name.ToString();
       
     }
   
   




}
