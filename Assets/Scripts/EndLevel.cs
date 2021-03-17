using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    public void quit ()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
