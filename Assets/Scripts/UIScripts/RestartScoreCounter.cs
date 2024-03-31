using UnityEngine;

public class RestartScoreCounter : MonoBehaviour
{
    [SerializeField] private GameObject _scoreCounter;

    public void CounterOn()
    {
        _scoreCounter.SetActive(true);
        GlobalVariables.AddGameLauncherCount();
        GlobalVariables.ResetGameCounter();
    }

    public void CounterOff() 
    {
        _scoreCounter.SetActive(false);
    }    
}
