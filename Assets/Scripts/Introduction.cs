using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Introduction : MonoBehaviour
{ public GameObject IntroductionUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        if (ResumeGame.GameIsPause == false)
            IntroductionUI.SetActive(true);
     else 
           IntroductionUI.SetActive(false);
       
        
    }
  
}
