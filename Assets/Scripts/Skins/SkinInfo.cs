using UnityEngine;

public abstract class SkinInfo : ScriptableObject
{
    [field: SerializeField] public Sprite Image { get; private set; }
    public int Price { get; private set; }

}
