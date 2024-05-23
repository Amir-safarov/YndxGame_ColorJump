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
        switch (key)
        {
            case "1":
                print($"DOUBLE STARS INVOKE \n Yandex {YandexGame.savesData.doubleStartsBought}");
                if (YandexGame.SDKEnabled)
                {
                    YandexGame.savesData.doubleStartsBought = true;
                    YandexGame.SaveProgress();
                    print($"DOUBLE STARS PAID AND SAVED\n Yandex {YandexGame.savesData.doubleStartsBought}  {YandexGame.PaymentsData.purchased[1]}");
                    _doubleStarsObj.SetActive(!YandexGame.savesData.doubleStartsBought);
                    YandexGame.GetPayments();
                }
                break;
            default: break;
        }
    }
}
