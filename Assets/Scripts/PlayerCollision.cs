using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{    public PlayerMove movement;
    public GameObject highScore;
    //public ParticleSystem ObstacleExplostion;
    //[HideInInspector]
    //public bool colide=false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            movement.enabled = false;
             //Instantiate(ObstacleExplostion, collision.transform);                     
            FindObjectOfType<GameMananger>().EndGame();
            /*  if (SceneManager.GetActiveScene().name == "FreeRide")
              {

                  GroundGenerator aux;
                  aux = highScore.GetComponent<GroundGenerator>();
                  aux.HighScore();
              }*/
        }
        if (collision.collider.tag == "Coin")
        {
            Destroy(collision.gameObject);
        }
    }
   

}
