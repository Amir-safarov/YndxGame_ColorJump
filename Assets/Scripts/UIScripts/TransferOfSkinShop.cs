using UnityEngine;

public class TransferOfSkinShop : MonoBehaviour
{
    [SerializeField] private RectTransform _shopUI;

    private void Awake() =>
        _shopUI.gameObject.SetActive(true);

    public void ShopOn()
    {
        _shopUI.localPosition = new Vector3 (0, 0, 0);
        GlobalEventManager.UpdateCoinsView();
    }

    public void ShopOff()
    {
        _shopUI.localPosition = new Vector3 (0, -4050, 0);
        GlobalEventManager.OnResetReceivedCoins();
    }
}
