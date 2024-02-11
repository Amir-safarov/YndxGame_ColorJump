using System.Collections.Generic;
using UnityEngine;

public class DeterminationColorsForWalls : MonoBehaviour
{
    [SerializeField] private bool _isRightWall;
    [SerializeField] private List<Transform> walls = new List<Transform>();
    public List<Color> sideColor = new List<Color>();

    private Colors _colors;

    private void Awake()
    {
        GlobalEventManager.ToLeftWallChangeColorEvent.AddListener(ForLeft);
        GlobalEventManager.ToRightWallChangeColorEvent.AddListener(ForRight);
    }

    private void Start()
    {
        FillTheWallList();
    }

    private void FillTheWallList()
    {
        walls.Clear();
        if (CheckListOnNull(walls))
            return;
        else
        {
            for (int i = 0; i < transform.childCount; i++)
                walls.Add(transform.GetChild(i));
            DeterminateColor(walls);
        }

    }
    internal void cleare()
    {
        walls.Clear();
        sideColor.Clear();
    }
    internal void UseTL()
    {
        FillTheWallList();
    }
    private bool CheckListOnNull(List<Transform> list)
    {
        if (list != null)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == null)
                {
                    list.RemoveAt(i);
                    CheckListOnNull(list);
                }
                else continue;
            }
            return false;
        }
        else return true;
    }

    private void ForRight()
    {
        if (_isRightWall)
            DeterminateColor(walls);
    }
    private void ForLeft()
    {
        if (!_isRightWall)
            DeterminateColor(walls);
    }

    private void DeterminateColor(List<Transform> wallPieces)
    {
        int previousColorIndex = -1;
        for (int i = 0; i < wallPieces.Count; i++)
        {
            _colors = new Colors();
            int colorIndex;

            do
                colorIndex = Random.Range(0,GlobalVariables.wallRank);
            while (colorIndex == previousColorIndex);

            wallPieces[i].GetComponent<SpriteRenderer>().color = _colors.colorsDict[colorIndex];
            previousColorIndex = colorIndex;
        }
        FillTheColorsList(transform, walls);
    }

    private void FillTheColorsList(Transform host, List<Transform> list)
    {
        sideColor.Clear();
        for (int i = 0; i < list.Count; i++)
            sideColor.Add(host.GetChild(i).GetComponent<SpriteRenderer>().color);
    }
}
