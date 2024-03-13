using System.Collections.Generic;
using UnityEngine;

public static class ParametersOfSelectedSkin 
{
    public static Dictionary<int, Color> skinsColor = new Dictionary<int, Color>()
    {
        { 0, new Color(0.67843f, 0.67843f, 0.67843f)},//Unselected
        { 1, new Color(0.4f, 1f, 0f)},//Selected
    };

    public static Dictionary<int, float> skinsSize = new Dictionary<int, float>()
    {
        { 0, 0.75f},//unselected
        { 1, 0.95f},//selected
    };
}
