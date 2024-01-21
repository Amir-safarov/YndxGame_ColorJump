using System;
using UnityEngine;
using UnityEngine.Events;

public class GlobalEventManager : MonoBehaviour
{
    public static UnityEvent OnPlayerBounced = new UnityEvent();

    public static void SendBounced()
    {
        OnPlayerBounced.Invoke();
    }
}
