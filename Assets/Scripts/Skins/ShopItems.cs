using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShopItems : MonoBehaviour
{
    [SerializeField] private List<SkinItem> skinItems;

    public void CheckSkinsState(SkinItem selectedItem)
    {
        var selectedSkin = skinItems.Where(x => x != selectedItem).ToList();
        foreach (var skinItem in selectedSkin)
        {
            skinItem.IsEquipped = false;
            skinItem.CheckSkinState();
        }
    }
}
