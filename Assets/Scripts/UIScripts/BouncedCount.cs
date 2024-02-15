using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class BouncedCount : MonoBehaviour
{
    private int _bounced = 0;

    private void Start()
    {
        GlobalEventManager.OnPlayerBouncedEvent.AddListener(PlayerBounced);
    }

    private void PlayerBounced()
    {
        _bounced++;
        GlobalEventManager.SendToUpgrade(_bounced);
        GetComponent<TextMeshProUGUI>().text = _bounced.ToString();
    }
}


