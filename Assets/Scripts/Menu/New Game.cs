using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class NewGame : MonoBehaviour
{
    // Start is called before the first frame update
    public IntVariable score;
    public void startGame()
    {
        SceneManager.LoadScene("Loading");
        Debug.Log("restarting");
        score.Value = 0;
    }
}
