using System.Collections.Generic;
using UnityEngine;

public class Colors
{
    public Dictionary<int, Color> colorsDict = new Dictionary<int, Color>()
    {
        { 0, new Color(0.9059f, 0.0549f, 0f)},//Red
        { 1, new Color(0.9686f, 0.9216f, 0.1490f)},//Yelloy
        { 2, new Color(0.5922f, 0.0745f, 1f)},//Purple
        { 3, new Color(0.298f, 0.8549f, 0.3922f)},//Green
        { 4, new Color(0.345f, 0.224f, 0.153f)},//Brown
        { 5, new Color(0f, 0.8706f, 1f)},//Cyan
    };
}
