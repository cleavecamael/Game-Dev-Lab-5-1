using UnityEngine;

[CreateAssetMenu(fileName = "EventManager", menuName = "ScriptableObjects/EventManager", order = 3)]
public class EventManager : ScriptableObject
{
    public delegate void gamingEvent();
    public gamingEvent onRestart;
    public gamingEvent onPause;
    public gamingEvent onResume;
    public gamingEvent onNextScene;
}

