using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
   public void Back()
    { if (ResumeGame.CurrentScene != "Start")
            SceneManager.LoadScene(ResumeGame.CurrentScene);
        else
            SceneManager.LoadScene("Start");
    }
}
