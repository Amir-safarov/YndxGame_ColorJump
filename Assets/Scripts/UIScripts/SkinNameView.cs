using TMPro;
using UnityEngine;

public class SkinNameView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _skinText;
    private void OnEnable()
    {
        GlobalEventManager.SkinNameChangeEvent += ChangeSkin;
    }

    private void OnDisable()
    {
        GlobalEventManager.SkinNameChangeEvent -= ChangeSkin;
    }

    private void ChangeSkin(PlayerSkin playerSkin)
    {
        _skinText.text = playerSkin.ToString();
    }
}
