using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private float originalX;
    private float maxOffset = 5.0f;
    private float enemyPatroltime = 2.0f;
    private int moveRight = -1;
    private Vector2 velocity;
    private Rigidbody2D enemyBody;
    public bool alive;
    public AudioSource enemyAudio;
    public Vector3 startPosition;

    void Start()
    {
        enemyBody = GetComponent<Rigidbody2D>();
        // get the starting position
        startPosition = transform.localPosition;
        originalX = transform.position.x;
        alive = true;
        ComputeVelocity();
       
    }
    void ComputeVelocity()
    {
        velocity = new Vector2((moveRight) * maxOffset / enemyPatroltime, 0);
    }
    void Movegoomba()
    {
        enemyBody.MovePosition(enemyBody.position + velocity * Time.fixedDeltaTime);
    }

    void Death()
    {
        enemyBody.transform.gameObject.SetActive(false);
    }
    public void StompDeath()
    {
        if (alive)
        {
            enemyAudio.PlayOneShot(enemyAudio.clip, 0.9f);
            alive = false;
            this.gameObject.GetComponent<Animator>().SetTrigger("onKill");
        }
       
        
    }

    public void SpinDeath()
    {
        
        if (alive)
        {
            alive = false;
            enemyAudio.PlayOneShot(enemyAudio.clip, 0.9f);
            Transparent();
            Spin();
            enemyBody.gravityScale = 2;
        }
       
       

    }

    void Spin()
    {
        enemyBody.angularVelocity = 1000.0f;    // spin around +Z at 1rad/sec
        enemyBody.angularDrag = 0.0f;        // don't slow
    }
    void Transparent()
    {
        this.gameObject.layer = 10;
        enemyBody.bodyType = RigidbodyType2D.Dynamic;
    }

    void Update()
    {
        if (Mathf.Abs(enemyBody.position.x - originalX) < maxOffset)
        {// move goomba
            Movegoomba();
        }
        else
        {
            // change direction
            moveRight *= -1;
            ComputeVelocity();
            Movegoomba();
        }
    }
    public void Reset()
    {
        enemyBody.transform.localPosition = startPosition;
        this.gameObject.layer = 7;
        enemyBody.bodyType = RigidbodyType2D.Kinematic;
        enemyBody.angularVelocity = 0f;
        enemyBody.angularDrag = 1f;
        enemyBody.velocity = Vector2.zero;
        enemyBody.transform.rotation = quaternion.identity;
        // reset Goomba

    }
}