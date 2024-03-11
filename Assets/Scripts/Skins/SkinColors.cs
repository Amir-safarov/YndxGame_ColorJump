using System.Collections.Generic;
using UnityEngine;

public static class SkinColors 
{
    public static Dictionary<int, Color> skinsColor = new Dictionary<int, Color>()
    {
        { 0, new Color(0.67843f, 0.67843f, 0.67843f)},//Unselected
        { 1, new Color(0.4f, 1f, 0f)},//Selected
    };
}
