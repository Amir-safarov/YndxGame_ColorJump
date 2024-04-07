using UnityEngine;

public class UIVisibilityController : MonoBehaviour
{
    [SerializeField] private GameObject _shop;

    public void ObjectOn()
    {
        _shop.SetActive(true);
    }

    public void ObjectOff()
    {
        _shop.SetActive(false);
    }
}
