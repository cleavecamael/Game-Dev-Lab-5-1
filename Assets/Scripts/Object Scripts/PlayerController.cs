using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    private Rigidbody2D marioBody;
    public float upSpeed = 10;
    private bool onGroundState = true;
    private SpriteRenderer marioSprite;
    private bool faceRightState = true;
    public TextMeshProUGUI scoreText;
    public GameObject enemies;


    public Animator marioAnimator;
    public AudioSource marioAudio;
    public AudioSource deathAudio;
    public AudioClip marioDeath;
    public GameManager gameManager;
    public float deathImpulse;
    private bool moving = false;
    private bool jumpedState = false;
    public GameObject GameOverPanel;
    public TextMeshProUGUI gameOverText;
    [System.NonSerialized]
    public Vector2 startPosition;
    [System.NonSerialized]
    public bool alive = Variables.alive;
    public SimpleGameEvent gameOver;
    public SimpleGameEvent playerDamage;
    BoxCollider2D marioCollider;
    public AudioClip turnBig;
    public AudioClip turnSmall;
    public Sprite smallSprite;
    public Sprite bigSprite;
    public AudioClip rainbow;
    public AudioClip powerdown;
    int collisionLayerMask = (1 << 3) | (1 << 6) | (1 << 7) | (1 << 8);
    public BoolVariable faceRight;
    private Buff currentBuff;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.localPosition;
        currentBuff = this.gameObject.GetComponent<BuffStateController>().currentBuff;
        // Set to be 30 FPS
        Application.targetFrameRate = 30;
        marioBody = GetComponent<Rigidbody2D>();
        marioSprite = GetComponent<SpriteRenderer>();
        Time.timeScale = 1.0f;
        Variables.alive = true;
        SceneManager.activeSceneChanged += SetStartingPosition;

    }

    // Update is called once per frame
    void Update()
    {
        marioAnimator.SetFloat("xSpeed", Mathf.Abs(marioBody.velocity.x));
    }
    public float maxSpeed = 20;
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Colliding  " + col.gameObject.name);
        if (((collisionLayerMask & (1 << col.transform.gameObject.layer)) > 0) & !onGroundState)
        {
            onGroundState = true;

            marioAnimator.SetBool("onGround", onGroundState);
        }
        if ((col.gameObject.tag) == "Enemy")
        {
            if (col.gameObject.GetComponent<EnemyMovement>().alive)
            {
               if (this.gameObject.GetComponent<BuffStateController>().currentBuff == Buff.Invincible)
                {
                    col.gameObject.GetComponent<EnemyMovement>().SpinDeath();
                }
                else
                {
                    Debug.Log("damaged");
                    playerDamage.Raise(this);
                }
                
            }

        }
        if ((col.gameObject.tag) == "Powerup")
        {
            
            GetComponent<MarioStateController>().SetPowerup(col.gameObject.GetComponent<BasePowerup>().powerupType);
            currentBuff = GetComponent<BuffStateController>().currentBuff;
            if( currentBuff.Equals(Buff.Default)){
                GetComponent<BuffStateController>().SetBuff(col.gameObject.GetComponent<BasePowerup>().buff);
            }
        }

           
    }
    // FixedUpdate may be called once per frame. See documentation for details.
    public void onGameOver()
    {
        if (!marioAnimator.GetBool("deadLock"))
        {
            Debug.Log("test");
            onGroundState = true;
            // update animator state
            marioAnimator.SetBool("onGround", onGroundState);
            marioAnimator.SetTrigger("died");
            marioAnimator.SetBool("deadLock", true);
         
        }
    }
    public void updateRender(Sprite newSprite)
    {

        Vector3 v = newSprite.bounds.size;
        BoxCollider2D collider = this.gameObject.GetComponent<BoxCollider2D>();
       
        collider.size = v;
        GameManagers.getBoots().GetComponent<BootsMovement>().updatePosition(collider.bounds.min.y);

    }
    public void renderSmall()
    {
        updateRender(smallSprite);
    }
    public void renderBig()
    {
        updateRender(bigSprite);
    }
    void FixedUpdate()
    {


        if (Variables.alive && moving)
        {
            Move(faceRightState == true ? 1 : -1);
        }   



    }

    public void pauseAudio()
    {
        marioAudio.Pause();
    }

    public void resumeAudio()
    {
        marioAudio.UnPause();
    }
    public void freezeTime()
    {
        Time.timeScale = 0.0f;
    }


    void Move(int value)
    {
        Vector2 movement = new Vector2(value, 0);
        // check if it doesn't go beyond maxSpeed
        if (marioBody.velocity.magnitude < maxSpeed)
            marioBody.AddForce(movement * speed);
    }
    public void MoveCheck(int value)
    {

        if (value == 0)
        {

            moving = false;
        }
        else
        {

            FlipMarioSprite(value);
            moving = true;
            Move(value);
        }
    }
    void FlipMarioSprite(int value)
    {
        if (value == -1 && faceRightState)
        {
            faceRightState = false;
            marioSprite.flipX = true;
            if (marioBody.velocity.x > 0.05f)
                marioAnimator.SetTrigger("onSkid");

        }

        else if (value == 1 && !faceRightState)
        {
            faceRightState = true;
            marioSprite.flipX = false;
            if (marioBody.velocity.x < -0.05f)
                marioAnimator.SetTrigger("onSkid");
        }
        faceRight.SetValue(faceRightState);

    }

    public void Jump()
    {

        if (Variables.alive && onGroundState)
        {
            // jump

            marioBody.AddForce(Vector2.up * upSpeed, ForceMode2D.Impulse);
            onGroundState = false;
            jumpedState = true;
            // update animator state
            marioAnimator.SetBool("onGround", onGroundState);

        }
    }

    public bool isBig()
    {
        return !(this.GetComponent<MarioStateController>().currentPowerupType.Equals(PlayerState.small));
    }
    public void JumpHold()
    {
        if (Variables.alive && jumpedState)
        {
            // jump higher
            marioBody.AddForce(Vector2.up * upSpeed * 30, ForceMode2D.Force);
            jumpedState = false;

        }
    }


    void PlayDeathImpulse()
    {
        marioBody.AddForce(Vector2.up * deathImpulse, ForceMode2D.Impulse);
    }
    void PlayJumpSound()
    {
        // play jump sound
        marioAudio.PlayOneShot(marioAudio.clip);
    }

    void PlayDeathSound()
    {
        deathAudio.PlayOneShot(deathAudio.clip);
    }

    public void SetStartingPosition(Scene current, Scene next)
    {
        if (next.name == "Stage 1-2")
        {
            // change the position accordingly in your World-1-2 case
            Debug.Log("yes");
        }
    }
    public void playRainbow()
    {
        marioAudio.PlayOneShot(rainbow);
        
    }
    public void playPowerDown()
    {
        marioAudio.PlayOneShot(powerdown);

    }
    public void stopAudio()
    {
        marioAudio.Stop();
    }
  
    public void DamageMario()
    {
        // GameOverAnimationStart(); // last time Mario dies right away
        Debug.Log("Here");
        // pass this to StateController to see if Mario should start game over
        // since both state StateController and MarioStateController are on the same gameobject, it's ok to cross-refer between scripts
        GetComponent<MarioStateController>().SetPowerup(PowerupType.Damage);

    }
    void playBigclip()
    {
        GetComponent<AudioSource>().PlayOneShot(turnBig);
    }

    void playSmallClip()
    {
        GetComponent<AudioSource>().PlayOneShot(turnSmall);
    }
    void endMushroomAnim()
    {
        Debug.Log("resetting scale");
        Time.timeScale = 1.0f;

    }
   
}
