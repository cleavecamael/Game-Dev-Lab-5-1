using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class BootsMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource bootAudio;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updatePosition(float y)
    {
        float currX = this.transform.position.x;
        float halfSize = this.gameObject.GetComponent<BoxCollider2D>().size.y / 2.0f;
       // float playerBoundsY = mario.bounds.min.y;
        this.transform.localPosition = new Vector2(currX, y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyMovement>().StompDeath();
            //bootAudio.PlayOneShot(bootAudio.clip,0.9f);
            //inefficient method
            //collision.gameObject.GetComponent<EnemyMovement>().alive = false;
           //collision.gameObject.GetComponent<Animator>().SetTrigger("onKill");
           
            
        }
    }
}
