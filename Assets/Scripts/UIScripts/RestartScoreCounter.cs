using TMPro;
using UnityEngine;

public class RestartScoreCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreCounter;

    public void CounterOn()
    {
        _scoreCounter.color = new Color(0.396f, 0.396f, 0.396f, 1);
        GlobalVariables.AddGameLauncherCount();
        GlobalVariables.ResetGameCounter();
        GlobalEventManager.InvokeShowBouncedCount();
    }

    public void CounterOff() 
    {
        _scoreCounter.color = new Color(0.396f, 0.396f, 0.396f, 0);
        GlobalEventManager.InvokeShowBouncedCount();
    }
}
