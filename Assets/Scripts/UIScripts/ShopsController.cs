using UnityEngine;

public class ShopsController : MonoBehaviour
{
    [SerializeField] private GameObject _shop;
    private void Start()
    {
        ShopOff();
    }
    public void ShopOn()
    {
        _shop.SetActive(true);
    }

    public void ShopOff()
    {
        _shop.SetActive(false);
    }
}
