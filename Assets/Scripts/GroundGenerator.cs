using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    public GameObject[] Obstacles;
    public GameObject End;
    public GameObject Player;
    public float DistanceBetweenObstacles;
    public float EndNextCoordinate;
    public GameObject scoreUI;
    [HideInInspector]
    public int RandomNumber;
    [HideInInspector]
    public Vector3 SpawnCoordonate = Vector3.zero;
   
  private int   Returnint(string noun)
    {
        int i = 0;
        int  number=0;
        
         for(i=0;i<noun.Length;i++)
         {          
            int n =noun[i] - '0';           
            number = number * 10+n ;                      
         }
        return number;      
    }
    public void HighScore()
    {
        Score score;
        score = scoreUI.GetComponent<Score>();       
          int  highscore = PlayerPrefs.GetInt("highscore", 0);
          int  highcurent = Returnint(score.scoreText.text);
         if (highscore < highcurent)
             highscore =highcurent;        
          PlayerPrefs.SetInt("highscore", highscore);
          Debug.Log(highscore.ToString());       
         


    }
    // Start is called before the first frame update
    void Start()
    {    
        SpawnCoordonate = End.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       RandomNumber = Random.Range(0,7);
              
         if(End.transform.position.z - Player.transform.position.z< EndNextCoordinate)
        {
            Instantiate(Obstacles[RandomNumber], SpawnCoordonate, Quaternion.identity);
            End.transform.position += new Vector3(0, 0, DistanceBetweenObstacles);          
            SpawnCoordonate = new Vector3(End.transform.position.x, End.transform.position.y, End.transform.position.z);
        }
       
        
    }
}
