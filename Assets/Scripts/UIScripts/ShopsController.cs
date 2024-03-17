using UnityEngine;

public class ShopsController : MonoBehaviour
{
    [SerializeField] private GameObject _shop;
    
    public void ShopOn()
    {
        _shop.SetActive(true);
    }

    public void ShopOff()
    {
        _shop.SetActive(false);
    }
}
