using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMAudioManager : MonoBehaviour
{
    // Start is called before the first frame update
   public AudioSource cameraAudio;
    public AudioClip death;
    public AudioClip rainbow;
    public void playAudio()
    {
        Debug.Log("playing audio");
        cameraAudio.Stop();
        cameraAudio.PlayOneShot(cameraAudio.clip);
       
    }
    public void playDeath()
    {
        Debug.Log("playing death    ");
        cameraAudio.PlayOneShot(death);
    }
   public void stopAudio()
    {
        cameraAudio.Stop();
    }
    public void pauseAudio()
    {
        cameraAudio.Pause();
    }
    public void resumeAudio()
    {
        cameraAudio.UnPause();
    }
  
    void Start()
    {
        //eventManager.onResume += resumeAudio;
        //eventManager.onPause += pauseAudio;
        //eventManager.onRestart += playAudio;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
