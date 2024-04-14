using UnityEngine;

public class RestartMenuControl : MonoBehaviour
{
    [SerializeField] private GameObject _restartMenu;
    [SerializeField] private GameObject _bonuceObj;

    private void Start()
    {
        GlobalEventManager.RestartMenu.AddListener(RestartMenuOn);
    }
    public void RestartMenuOff()
    {
        _restartMenu.SetActive(false);
    }

    private void RestartMenuOn()
    {
        _restartMenu.SetActive(true);
        if (GlobalVariables.showBonuce)
            _bonuceObj.SetActive(true);
    }

}
