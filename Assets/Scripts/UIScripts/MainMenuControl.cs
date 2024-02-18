using UnityEngine;

public class MainMenuControl : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;

    private void Awake()
    {
        MainMenuOn();
    }
    public void MainMenuOff()
    {
        mainMenu.gameObject.SetActive(false);
    }
    public void MainMenuOn()
    {
        mainMenu.gameObject.SetActive(true);
    }
}
