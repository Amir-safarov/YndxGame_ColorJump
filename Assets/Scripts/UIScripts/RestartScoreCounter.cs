using UnityEngine;

public class RestartScoreCounter : MonoBehaviour
{
    [SerializeField] private GameObject _scoreCounter;

    public void CounterOn()
    {
        _scoreCounter.SetActive(true);
    }

    public void CounterOff() 
    {
        _scoreCounter.SetActive(false);
    }    
}
