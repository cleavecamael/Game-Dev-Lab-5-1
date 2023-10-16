using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rainbow : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        SetRendererToFlicker();
    }
    public void SetRendererToFlicker()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(BlinkSpriteRenderer());
    }

    private IEnumerator BlinkSpriteRenderer()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        bool blink = false;
        Color temp;
        while (true)
        {
            temp = spriteRenderer.color;
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
            yield return new WaitForSeconds(0.3f);
        }

        spriteRenderer.enabled = true;
    }

  
}
