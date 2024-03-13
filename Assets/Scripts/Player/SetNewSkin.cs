using UnityEngine;

public class SetNewSkin : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _playerSprite;

    private void OnEnable()
    {
        GlobalEventManager.PlayersSkinChangeEvent += ChangePlayerSkin;
    }

    private void OnDisable()
    {
        GlobalEventManager.PlayersSkinChangeEvent -= ChangePlayerSkin;
    }

    private void ChangePlayerSkin(Sprite skinSprite)
    {
        _playerSprite.sprite = skinSprite;
    }
}
