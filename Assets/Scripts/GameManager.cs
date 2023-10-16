using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public GameObject GameOverPanel;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText;
    public GameObject player;
    public GameObject enemies;

    public Camera gameCamera;
    public EventManager eventManager;
    //global variables

    public SimpleGameEvent gameOver;
    public bool alive = true;
    public SimpleGameEvent updateScore;
    public SimpleGameEvent gameStart;
    public IntVariable score;
    // Start is called before the first frame update
    void Start()
    {
        
        //gameStart.Invoke();
        Time.timeScale = 1.0f;
        updateScore.Raise(this);
        gameStart.Raise(this);

    }

    // Update is called once per frame
    void Update()
    {

    }
 
    public void Restart()
    {
        //freezeTime();
        score.Value = 0;

    }
    public void freezeTime()
    {
        Time.timeScale = 0.0f;
    }
    public void onIncreaseScore(int increment)
    {
        Debug.Log("increment " + increment.ToString());
        score.ApplyChange(increment);
        Debug.Log("log is " + score.Value.ToString());
        updateScore.Raise(this);
        
    }

  

 

}
