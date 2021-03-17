using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSkin : MonoBehaviour
{
    public Renderer Player;
    public Material[] MaterialArray;
    // Start is called before the first frame update
    void Start()
    {
        Player.material = MaterialArray[PlayerPrefs.GetInt("ChosenSkin")];
        Debug.Log(PlayerPrefs.GetInt("ChosenSkin"));
      
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void PlayWithSelectedSkin()
    {
      
      
    }
}
