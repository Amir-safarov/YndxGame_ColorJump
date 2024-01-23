using System;
using UnityEngine;
using UnityEngine.Events;

public class GlobalEventManager : MonoBehaviour
{
    public static UnityEvent OnPlayerBouncedEvent = new UnityEvent();
    public static UnityEvent ToLeftWallChangeColorEvent = new UnityEvent();
    public static UnityEvent ToRightWallChangeColorEvent = new UnityEvent();
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
