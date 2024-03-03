using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "Skin", menuName = "SkinsShop/Skin")]
public class Skin : SkinInfo
{
    [field:SerializeField]public CharactersSckins ABC { get; private set; }

}
