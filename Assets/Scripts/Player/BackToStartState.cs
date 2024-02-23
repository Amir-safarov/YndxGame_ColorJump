using UnityEngine;

public class BackToStartState : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private PlayerChangeColor _playerChangeColor;
    [SerializeField] private DeterminationColorsForWalls _rightWalls;
    [SerializeField] private DeterminationColorsForWalls _leftWalls;
    [SerializeField] private GlobalVariables _variables;
    [SerializeField] private UpgradeWalls _rightWallsUpgrade;
    [SerializeField] private UpgradeWalls _leftWallsUpgrade;

    public void ReturnState()
    {
        _variables.ResetToDeafoult();
        _rightWallsUpgrade.RebuildingWalls();
        _leftWallsUpgrade.RebuildingWalls();
        _player.transform.position = new Vector3(-2, 0, 0);
        _rightWalls.FillTheWallList();
        _leftWalls.FillTheWallList();
        _playerChangeColor.ResetDirection();
        _playerChangeColor.GetNewColor();
    }

}
