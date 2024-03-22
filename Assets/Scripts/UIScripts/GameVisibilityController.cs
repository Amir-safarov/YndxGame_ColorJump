using UnityEngine;

public class WallsVisibilityController : MonoBehaviour
{
    [SerializeField] private GameObject _walls;

    private void WallOn()
    {
        _walls.SetActive(true);
    } 

    private void WallOff()
    {
        _walls.SetActive(false);
    }
}
