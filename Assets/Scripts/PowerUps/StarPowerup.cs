using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPowerup : BasePowerup
{
    public AudioClip spawnclip;
    AudioSource spawnSource;
   public float velocityX;
   public float velocityY;
    Vector2 temp;
    protected override void Start()
    {
        base.Start(); // call base class Start()
        this.type = PowerupType.StarMan;
        spawnSource = this.GetComponent<AudioSource>();

        spawned = false;
        SpawnPowerup();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(spawned.ToString());
        if (col.gameObject.CompareTag("Player") && spawned)
        {


            DestroyPowerup();

        }

    }
    public override void ApplyPowerup(MonoBehaviour i)
    {
        throw new System.NotImplementedException();
    }

    public override void SpawnPowerup()
    {
        Debug.Log(spawnSource.name);
        spawnSource.PlayOneShot(spawnclip);
        spawned = true;
        rigidBody.AddForce(Vector2.up * 100);
        rigidBody.AddForce(Vector2.right * 20);
       
    }


    // Update is called once per frame
    void Update()
    {
     

       
    }
}
