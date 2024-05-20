using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class SkinItem : MonoBehaviour
{
    private const int unselectedColorNumber = 0;
    private const int selectedColorNumber = 1;
    private float skinScale;
    private int _skinCost = 100;

    [SerializeField] private Sprite _skinImage;
    [SerializeField] private PlayerSkin _skinsType;
    [SerializeField] private Image _childImage;
    [SerializeField] private GameObject _buyButton;
    [SerializeField] private GameObject _selectButton;
    [SerializeField] private ShopItems _shopItems;
    [SerializeField] private CoinsValue _coins;
    [SerializeField] private TextMeshProUGUI _skinText;


    public bool IsPurchased { get; private set; }
    public bool IsEquipped { get; set; }

    private void OnValidate()
    {
        foreach (PlayerSkin skin in (PlayerSkin[])Enum.GetValues(typeof(PlayerSkin)))
        {
            if (skin.ToString() == _skinImage.name)
            {
                _skinsType = skin;
                break;
            }
        }
        _childImage.sprite = _skinImage;
    }

    private void Awake()
    {
        UpdateSkinState();
/*        ChangeSkin();
*/    }

    public void UpdateSkinState()
    {
        LoadSkinPurchaseStatus();
        LoadEquippedSkin();
        CheckSkinState();
    }

    public void CheckSkinState()
    {
        if (IsEquipped && IsPurchased)
        {
            BuyButtonOff();
            SelectButtonOff();
            skinScale = ParametersOfSelectedSkin.skinsSize[selectedColorNumber];
            _childImage.color = ParametersOfSelectedSkin.skinsColor[selectedColorNumber];
            _childImage.transform.localScale = new Vector2(skinScale, skinScale);
            GlobalEventManager.ChangeSkin(_skinImage);
            GlobalEventManager.ChangeSkinName(_skinsType);
            return;
        }
        if (IsPurchased)
        {
            BuyButtonOff();
            if (!IsEquipped)
                SelectButtonOn();
            skinScale = ParametersOfSelectedSkin.skinsSize[unselectedColorNumber];
            _childImage.color = ParametersOfSelectedSkin.skinsColor[unselectedColorNumber];
            _childImage.transform.localScale = new Vector2(skinScale, skinScale);
            return;
        }
        if (!IsPurchased || (!IsEquipped && !IsPurchased))
        {
            BuyButtonOn();
            SelectButtonOff();
            skinScale = ParametersOfSelectedSkin.skinsSize[unselectedColorNumber];
            _childImage.color = ParametersOfSelectedSkin.skinsColor[unselectedColorNumber];
            _childImage.transform.localScale = new Vector2(skinScale, skinScale);
            return;
        }
    }

    public void SelectButtonOn()
    {
        _selectButton.SetActive(true);
    }

    public void BuyButtonClick()
    {
        if (!IsPurchased && (_coins.GetCurrentCoinsCount() >= _skinCost || _skinsType == PlayerSkin.Circle))
        {
            IsPurchased = true;
            PlayerPrefs.SetInt(_skinsType.ToString() + "Purchased", 1);
            PlayerPrefs.Save();
            _coins.BuyNewSkin();
            BuyButtonOff();
            if (!IsEquipped)
                SelectButtonOn();
            GlobalEventManager.UpdateCoinsView();
            GlobalVariables.BoughtSkinsCount++;
            if (YandexGame.SDKEnabled)
            {
                YandexGame.savesData.skinsCount = GlobalVariables.BoughtSkinsCount;
                YandexGame.SaveProgress();
            }
            Debug.Log($"Куплен скин: {_skinsType}");
        }
        else
            print("Мало деняг");
        print("Нажатие  на покупку прошло");
    }

    public void EquipButtonClick()
    {
        if (IsPurchased && !IsEquipped)
        {
            UnequipPreviousSkin();

            IsEquipped = true;
            SaveEquippedSkin();

            SelectButtonOff();
        }
        CheckSkinState();
        _shopItems.CheckSkinsState(this);
        Debug.Log($"Надет скин: {_skinsType}");
    }

    private void LoadSkinPurchaseStatus()
    {
        IsPurchased = PlayerPrefs.GetInt(_skinsType.ToString() + "Purchased", 0) == 1;
    }

    private void LoadEquippedSkin()
    {
        string equippedSkin;
        if (!PlayerPrefs.HasKey("EquippedSkin") && _skinsType == PlayerSkin.Circle)
        {
            EqupDefaultSkin();
            EquipButtonClick();
        }
        else
        {
            equippedSkin = PlayerPrefs.GetString("EquippedSkin", "");

            if (!string.IsNullOrEmpty(equippedSkin) && Enum.IsDefined(typeof(PlayerSkin), equippedSkin))
            {
                PlayerSkin skin = (PlayerSkin)Enum.Parse(typeof(PlayerSkin), equippedSkin);

                if (skin == _skinsType)
                    IsEquipped = true;
                else
                    IsEquipped = false;
            }
        }
    }

    private void BuyButtonOn()
    {
        _buyButton.SetActive(true);
    }

    private void BuyButtonOff()
    {
        _buyButton.SetActive(false);
    }

    private void SelectButtonOff()
    {
        _selectButton.SetActive(false);
    }

/*    private void ChangeSkin()
    {
        _skinText.text = _skinsType.ToString();
    }*/

    private void EqupDefaultSkin()
    {
        IsPurchased = true;
        PlayerPrefs.SetInt(_skinsType.ToString() + "Purchased", 1);
        PlayerPrefs.Save();
        _coins.BuyNewSkin();
        Debug.Log($"Надет обычный скин: {_skinsType}");
        BuyButtonOff();
        if (!IsEquipped)
            SelectButtonOn();
        GlobalEventManager.UpdateCoinsView();
    }

    private void UnequipPreviousSkin()
    {
        foreach (PlayerSkin skin in (PlayerSkin[])Enum.GetValues(typeof(PlayerSkin)))
        {
            if (PlayerPrefs.GetInt(skin.ToString() + "Purchased", 0) == 1)
            {
                PlayerPrefs.SetInt(skin.ToString() + "Equipped", 0);
            }
        }
    }

    private void SaveEquippedSkin()
    {
        PlayerPrefs.SetInt(_skinsType.ToString() + "Equipped", 1);
        PlayerPrefs.SetString("EquippedSkin", _skinsType.ToString());
        PlayerPrefs.Save();
    }
}
