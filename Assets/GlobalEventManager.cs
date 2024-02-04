using System;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Events;

public class GlobalEventManager : MonoBehaviour
{
    public static UnityEvent OnPlayerBouncedEvent = new UnityEvent();
    public static UnityEvent ToLeftWallChangeColorEvent = new UnityEvent();
    public static UnityEvent ToRightWallChangeColorEvent = new UnityEvent();
    public static UnityEvent<int> OnBouncedCountReached = new UnityEvent<int>();

    public static void SendToUpgrade(int bounced)
    {
        OnBouncedCountReached.Invoke(bounced); 
    }
    public static void SendBounced()
    {
        OnPlayerBouncedEvent.Invoke();
    }
    public static void RightWallChangeColor()
    {
        ToRightWallChangeColorEvent.Invoke();
    }
    public static void LeftWallChangeColor()
    {
        ToLeftWallChangeColorEvent.Invoke();
    }
}
