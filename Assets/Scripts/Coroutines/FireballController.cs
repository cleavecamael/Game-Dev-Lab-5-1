using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

public class FireballController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float scaleSpeed = 1.0f;
    public float velocityX;
    public float velocityY;
    Vector2 temp;
     
    void Start()
    {
        StartCoroutine(ScaleAndDestroyCoroutine());
        GetComponent<AudioSource>().Play();
    }

    private IEnumerator ScaleAndDestroyCoroutine()
    {
        // Wait for 2 seconds
        yield return new WaitForSecondsRealtime(2);
        // Gradually scale down the GameObject
        while (transform.localScale.x > 0.01f)
        {
            transform.localScale -= Vector3.one * scaleSpeed * Time.deltaTime;
            yield return null;
        }

        // Ensure the GameObject is completely scaled down
        transform.localScale = Vector3.zero;

        // Destroy the GameObject
        Destroy(gameObject);
    }
    void Update()
    {
        Vector2 currVelocity = this.gameObject.GetComponent<Rigidbody2D>().velocity;
        temp = currVelocity;
        if (temp.x > 0){
            temp.x = velocityX;
        }
        else
        {
            Debug.Log("here change direction");
            temp.x = -velocityX;
        }

        if (temp.y > velocityY)
        {
            temp.y = velocityY;
        }
        if  (temp.y < -velocityY)
        {
            temp.y = -velocityY;
        }


        this.gameObject.GetComponent<Rigidbody2D>().velocity = temp;

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            // destroy self
            collision.gameObject.GetComponent<EnemyMovement>().SpinDeath();
            Destroy(this.gameObject);
        }
    }
}