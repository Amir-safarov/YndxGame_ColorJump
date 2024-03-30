using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShopItems : MonoBehaviour
{
    [SerializeField] private List<SkinItem> skinItems;

    private void Awake()
    {
        if (skinItems.Count < 0)
            Debug.LogError("Skins list empty");
    }

    public void CheckSkinsState(SkinItem selectedItem)
    {
        var selectedSkin = skinItems.Where(x => x != selectedItem).ToList();
        foreach (var skinItem in selectedSkin)
        {
            skinItem.IsEquipped = false;
            skinItem.CheckSkinState();
        }
    }
    public void CheckAllSkinsState()
    {
        foreach (var skinItem in skinItems)
        {
            skinItem.IsEquipped = false;
            skinItem.UpdateSkinState();
        }
    }
}
