using System;
using UnityEngine;

public class RestartMenuControl : MonoBehaviour
{
    [SerializeField] private GameObject _restartMenu;
    private void Start()
    {
        GlobalEventManager.PlayereDeadEvent.AddListener(RestartMenuOn);
    }

    private void RestartMenuOn()
    {
        _restartMenu.gameObject.SetActive(true);
    }
    public void RestartMenuOff()
    {
        _restartMenu.gameObject.SetActive(false);
    }
}
