using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToStartState : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private PlayerChangeColor _playerChangeColor;
    [SerializeField] private DeterminationColorsForWalls _rightWalls;
    [SerializeField] private DeterminationColorsForWalls _leftWalls;

    public void ReturnState()
    {
        _player.transform.position = new Vector3(-2, 0, 0);
        _playerChangeColor.GetNewColor();
    }

}
