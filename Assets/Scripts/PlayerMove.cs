using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody rb;
    public float ForwardForce = 2000f;
    public static float SideWayForce = 80f;
    [HideInInspector]
    public float dirX;
   
    // Start is called before the first frame update
    void Start()
    {
        SideWayForce = PlayerPrefs.GetFloat("SideForce");
        Debug.Log(SideWayForce);
      
    }

    // Update is called once per frame
    void FixedUpdate()
    {       
        rb.AddForce(0, 0, ForwardForce*Time.deltaTime);
        if(Input.GetKey("d") || Input.GetKey("right"))
        {
            rb.AddForce(SideWayForce * Time.deltaTime, 0,0,ForceMode.VelocityChange);
           
        }
        if(Input.GetKey("a") || Input.GetKey("left"))
        {
            rb.AddForce(-SideWayForce* Time.deltaTime, 0, 0,ForceMode.VelocityChange);
        }
        if(rb.position.y<-1f)
        {
            FindObjectOfType<GameMananger>().EndGame();
        }
        dirX = CrossPlatformInputManager.GetAxis("Horizontal") * SideWayForce;
        rb.AddForce(dirX*Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }
  
}
