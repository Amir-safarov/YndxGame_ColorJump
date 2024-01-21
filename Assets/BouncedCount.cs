using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BouncedCount : MonoBehaviour
{
    private int _bounced = 0;
    private void Start()
    {
        GlobalEventManager.OnPlayerBounced.AddListener(PlayerBounced);
    }
    private void PlayerBounced()
    {
        _bounced++;
        GetComponent<TextMeshProUGUI>().text = _bounced.ToString();
    }
}
