using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffStateController : StateController
{
    public Buff currentBuff = Buff.Default;
    public Buff shouldBeNextState = Buff.Default;
    private SpriteRenderer spriteRenderer;
    public GameConstants gameConstants;

    public override void Start()
    {
        base.Start();
        GameRestart(); // clear powerup in the beginning, go to start state
    }

    // this should be added to the GameRestart EventListener as callback
    public void GameRestart()
    {
        // clear powerup
        currentBuff  = Buff.Default;
        // set the start state
        TransitionToState(startState);
    }
    public void SetBuff(Buff i)
    {
        currentBuff = i;
    }

    public void SetRenderertoRainbow()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(RainbowSpriteRenderer());
    }

    private IEnumerator RainbowSpriteRenderer()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        bool blink = false;

        while (string.Equals(currentState.name, "Invincible", StringComparison.OrdinalIgnoreCase))
        {
            // Toggle the visibility of the sprite renderer
            blink = !blink;
            if (blink)
            {
                spriteRenderer.color = Color.magenta;
            }
            else
            {
                spriteRenderer.color = Color.white;
            }

            // Wait for the specified blink interval
            //yes I'm lazy
            yield return new WaitForSeconds(gameConstants.flickerInterval);
        }

    }
    public void resetRainbow()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.white;
    }


}
