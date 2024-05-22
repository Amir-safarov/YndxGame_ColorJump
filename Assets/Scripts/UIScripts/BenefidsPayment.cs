using UnityEngine;
using YG;

public class BenefidsPayment : MonoBehaviour
{
    [SerializeField] private GameObject _doubleStarsObj;

    private void Awake()
    {
        if (YandexGame.SDKEnabled)
        {
            YandexGame.LoadProgress();
            print("HERE TO");
        }
    }

    private void OnEnable()
    {
        if (YandexGame.SDKEnabled)
            YandexGame.LoadProgress();
        YandexGame.PurchaseSuccessEvent += GetBenefids;
   }

    private void OnDisable()
    {
        if (YandexGame.SDKEnabled)
            YandexGame.LoadProgress();
        YandexGame.PurchaseSuccessEvent -= GetBenefids;
    }

    private void Start()
    {
        _doubleStarsObj.SetActive(!YandexGame.savesData.doubleStartsBought);
    }

    private void GetBenefids(string key)
    {
        if(!YandexGame.SDKEnabled)
            return;
        switch (key)
        {
            case "1":
                GlobalVariables.doubleStarsPaid = true;
                PlayerPrefs.SetInt("DoubleStarsPaid", 1);
                YandexGame.savesData.doubleStartsBought = true;
                YandexGame.SaveProgress();
                print("UNITY PAID");
                _doubleStarsObj.SetActive(!YandexGame.savesData.doubleStartsBought);
                break;
            default: break;
        }
    }
}
