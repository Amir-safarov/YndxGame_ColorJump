using System.Collections.Generic;

public class WallsPieceStats
{
    const float xAxisPos = 3.21f;

    public static Dictionary<int, float> yAaxisStartPositions = new Dictionary<int, float>()
    {
     { 3, 4},
     {4,4.5f},
     {5, 4.8f},
     {6, 5f}
    };

    public static Dictionary<int, float> yScale = new Dictionary<int, float>()
    {
     { 3, 4},
     {4,3f},
     {5, 2.4f},
     {6, 2f}
    };
}
