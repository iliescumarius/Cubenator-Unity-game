using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeRideCoin : MonoBehaviour
{
    public static int FreeRideCoins = 0;
    
    
    void Start()
    {
        
    }
    void Update()
    {
        this.transform.Rotate(0, 0, 90 * Time.deltaTime);

    }
    public void OnTriggerEnter(Collider other)
    { if (other.gameObject.name == "PlayerCharacter 1")
        {
          
            Destroy(this.gameObject);
            FreeRideCoins++;
           
        }
    }


}
