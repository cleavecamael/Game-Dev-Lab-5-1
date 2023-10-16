
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButtonController : EventManagerBehavior, IInteractiveButton
{
    private bool isPaused = false;
    public Sprite pauseIcon;
    public Sprite playIcon;
    public SimpleGameEvent onPause;
    public SimpleGameEvent onPlay;
    private Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ButtonClick()
    {
        Time.timeScale = isPaused ? 1.0f : 0.0f;
        isPaused = !isPaused;
        if (isPaused)
        {
            onPause.Raise(this);
            image.sprite = playIcon;
        }
        else
        {
            onPlay.Raise(this);
            image.sprite = pauseIcon;
        }
    }
}
