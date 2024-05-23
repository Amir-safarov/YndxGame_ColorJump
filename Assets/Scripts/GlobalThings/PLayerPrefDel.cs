using UnityEngine;
using YG;

public class PLayerPrefDel : MonoBehaviour
{
    private void Awake()
    {
        //PlayerPrefs.DeleteAll();
        //YandexGame.ResetSaveProgress();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Insert))
        {
            YandexGame.DeleteAllPurchases();
            YandexGame.savesData.doubleStartsBought = false;
            print("all puchases delete");
        }
    }
}
