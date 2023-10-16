using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPowerup : BasePowerup
{
    public AudioClip spawnClip;
    public AudioSource spawnSource;
    public IntGameEvent incrementScore;
    protected override void Start()
    {
        this.gameObject.SetActive(false);
        spawnSource = this.GetComponent<AudioSource>();
        SpawnPowerup();
    }
    public override void SpawnPowerup()
    {
        
        spawned = true;
        this.gameObject.SetActive(true);
        spawnSource.PlayOneShot(spawnClip);
       
        this.gameObject.GetComponent<Animator>().SetTrigger("jumped");
        incrementScore.Raise(1);
        
    }
    public override void ApplyPowerup(MonoBehaviour i)
    {
        // TODO: do something with the object

    }
}
