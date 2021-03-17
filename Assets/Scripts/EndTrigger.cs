using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameMananger gameMananger;
    public Coin coin;
    private void OnTriggerEnter()
    {
        gameMananger.WinLevel();
        gameMananger.CompleteLevel();      
       
    }
}
