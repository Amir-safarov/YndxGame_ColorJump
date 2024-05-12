using UnityEngine;
using YG;

public class BackToStartState : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private PlayerChangeColor _playerChangeColor;
    [SerializeField] private DeterminationColorsForWalls _rightWalls;
    [SerializeField] private DeterminationColorsForWalls _leftWalls;
    [SerializeField] private GlobalVariables _variables;
    [SerializeField] private UpgradeWalls _rightWallsUpgrade;
    [SerializeField] private UpgradeWalls _leftWallsUpgrade;
    [SerializeField] private PuckUpCoin _coin;


    public void ReturnState()
    {
        _variables.ResetToDeafoult();
        _rightWallsUpgrade.RebuildingWalls();
        _rightWallsUpgrade.beforeUp = true;
        _leftWallsUpgrade.RebuildingWalls();
        _leftWallsUpgrade.beforeUp = true;
        _player.transform.position = new Vector3(-2, 0, 0);
        _rightWalls.FillTheWallList();
        _leftWalls.FillTheWallList();
        _playerChangeColor.ResetDirection();
        _playerChangeColor.GetNewColor();
        _coin.ResetState();
        YandexGame.FullscreenShow();
    }

}
