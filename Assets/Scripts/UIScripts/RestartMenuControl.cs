using UnityEngine;

public class RestartMenuControl : MonoBehaviour
{
    [SerializeField] private GameObject _restartMenu;
    [SerializeField] private GameObject _bonuceObj;

    private void Start()
    {
        GlobalEventManager.PlayereDeadEvent.AddListener(RestartMenuOn);
    }

    private void RestartMenuOn()
    {
        _restartMenu.SetActive(true);
        if (GlobalVariables.showBonuce)
            _bonuceObj.SetActive(true);
    }

    public void RestartMenuOff()
    {
        _restartMenu.SetActive(false);
    }
}
