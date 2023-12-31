using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JumpOverGoomba : MonoBehaviour
{
    public Transform enemyLocation;
    public TextMeshProUGUI scoreText;
    private bool onGroundState;
    public GameObject enemies;

    private bool countScoreState = false;
    public Vector3 boxSize;
    public float maxDistance;
    public LayerMask layerMask;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    void FixedUpdate()
    {
        // mario jumps
        if (Input.GetKeyDown("space") && onGroundCheck())
        {
            onGroundState = false;
            countScoreState = true;
        }

        // when jumping, and Goomba is near Mario and we haven't registered our score
        if (!onGroundState && countScoreState)
        {
            foreach (Transform child in enemies.transform)
            {
              
                if (Mathf.Abs(transform.position.x - child.position.x) < 0.5f)
                {
                    countScoreState = false;
                    Variables.score++;
                    scoreText.text = "Score: " + Variables.score.ToString();
                  
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground")) onGroundState = true;
    }


    private bool onGroundCheck()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, maxDistance, layerMask))
        {
            
            return true;
        }
        else
        {
          
            return false;
        }
    }
    
    // helper
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(transform.position - transform.up * maxDistance, boxSize);
    }

}
