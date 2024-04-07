using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TransferOfSkinShop : MonoBehaviour
{
    [SerializeField] private RectTransform _shopUI;

    public void ShopOn()
    {
        _shopUI.localPosition = new Vector3 (0, 0, 0);
        GlobalEventManager.UpdateCoinsView();
    }

    public void ShopOff()
    {
        _shopUI.localPosition = new Vector3 (0, -405, 0);
        GlobalEventManager.OnResetReceivedCoins();
    }
}
