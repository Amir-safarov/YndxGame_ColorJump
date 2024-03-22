using System;
using UnityEngine;
using UnityEngine.Events;

public class GlobalEventManager : MonoBehaviour
{
    public static UnityEvent OnPlayerBouncedEvent = new UnityEvent();
    public static UnityEvent ToLeftWallChangeColorEvent = new UnityEvent();
    public static UnityEvent ToRightWallChangeColorEvent = new UnityEvent();
    public static UnityEvent PlayerDeadEvent = new UnityEvent();
    public static UnityEvent RestartMenu = new UnityEvent();
    public static UnityEvent CoinRespawnEvent = new UnityEvent();
    public static UnityEvent CoinView = new UnityEvent();
    public static UnityEvent CoinReceivedEvent = new UnityEvent();
    public static Action<Sprite> PlayersSkinChangeEvent;
    public static Action<PlayerSkin> SkinNameChangeEvent;
    public static UnityEvent<int> OnBouncedCountReached = new UnityEvent<int>();

    public static void SendToUpgrade(int bounced)
    {
        OnBouncedCountReached.Invoke(bounced); 
    }

    public static void ChangeSkin(Sprite skin)
    {
        PlayersSkinChangeEvent.Invoke(skin);
    }
    
    public static void ChangeSkinName(PlayerSkin skinName)
    {
        SkinNameChangeEvent.Invoke(skinName);
    }

    public static void SendToCoinRespawn()
    {
        CoinRespawnEvent.Invoke();
    }
    
    public static void ActivateRestarMenu()
    {
        RestartMenu.Invoke();
    }

    public static void SendToCoinReceive()
    {
        CoinReceivedEvent.Invoke();
    }
    public static void UpdateCoinsView()
    {
        CoinView.Invoke();
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

    public static void RegistradeOfDead()
    {
        PlayerDeadEvent.Invoke();
    }
}
