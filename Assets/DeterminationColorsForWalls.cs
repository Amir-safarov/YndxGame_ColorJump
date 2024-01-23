using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeterminationColorsForWalls : MonoBehaviour
{
    [SerializeField] private List<Transform> walls = new List<Transform>();
    [SerializeField] private bool _isRightWall;
    public List<Color> sideColor = new List<Color>();

    private Colors _colors;


    private void Start()
    {
        GlobalEventManager.ToLeftWallChangeColorEvent.AddListener(ForLeft);
        GlobalEventManager.ToRightWallChangeColorEvent.AddListener(ForRight);
        FillTheWallList(transform, walls);
        DeterminateColor(walls);
        FillTheColorsList(transform, walls);
    }
    private void FillTheWallList(Transform host, List<Transform> list)
    {
        if (CheckListOnNull(list))
            return;
        else
        {
            for (int i = 0; i < host.childCount; i++)
                list.Add(host.GetChild(i));
        }
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
        {
            DeterminateColor(walls);
            Debug.Log("Right Change");
        }
    }
    private void ForLeft()
    {
        if (!_isRightWall)
        {
            DeterminateColor(walls);
            Debug.Log("Left Change");
        }
    }

    private void DeterminateColor(List<Transform> wallPieces)
    {
        int previousColorIndex = -1;
        for (int i = 0; i < wallPieces.Count; i++)
        {
            _colors = new Colors();
            int colorIndex;

            do
                colorIndex = Random.Range(0, 3);
            while (colorIndex == previousColorIndex);

            wallPieces[i].GetComponent<SpriteRenderer>().color = _colors.colorsDict[colorIndex];
            previousColorIndex = colorIndex;
        }
    }

    private void FillTheColorsList(Transform host, List<Transform> list)
    {
        for (int i = 0; i < list.Count; i++)
            sideColor.Add(host.GetChild(i).GetComponent<SpriteRenderer>().color);
    }
}
