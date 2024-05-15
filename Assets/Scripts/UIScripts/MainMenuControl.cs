using UnityEngine;

public class MainMenuControl : MonoBehaviour
{
    [SerializeField] private UIVisibilityController mainMenu;

    private void Awake() =>
        MainMenuOn();

    public void MainMenuOff() =>
        mainMenu.ObjectOff();

    public void MainMenuOn() =>
        mainMenu.ObjectOn();
}
