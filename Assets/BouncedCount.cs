using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BouncedCount : MonoBehaviour
{
    private int _bounced = 0;
    private bool _isRankUpCalled;

    private void Start()
    {
        GlobalEventManager.OnPlayerBouncedEvent.AddListener(PlayerBounced);
    }
    private void PlayerBounced()
    {
        _bounced++;
        BouncedCallculate();
        GetComponent<TextMeshProUGUI>().text = _bounced.ToString();
    }

    private void BouncedCallculate()
    {
        switch (_bounced)
        {
            case (5):
                GlobalEventManager.RankUp();
                break;
            case (10):
                break;
            case (15):
                break;
            case (20):
                break;
            default:
                break;
        }
    }
    private void ResetRankUpCalled()
    {
        _isRankUpCalled = false;
    }
}
