using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeterminationColorsForWalls : MonoBehaviour
{
    [SerializeField] private bool _isRightWall;
    [SerializeField] private CircleMove _circleMove;
    [SerializeField] private GameObject _wallPiece;
    [SerializeField] private List<Transform> walls = new List<Transform>();
    public List<Color> sideColor = new List<Color>();

    private Colors _colors;
    private WallsPieceStats _wallPositions;
    int index = 4;

    private void Awake()
    {
        GlobalEventManager.ToWallsRankUp.AddListener(ReviewWalls);
    }
    private void Start()
    {
        GlobalEventManager.ToLeftWallChangeColorEvent.AddListener(ForLeft);
        GlobalEventManager.ToRightWallChangeColorEvent.AddListener(ForRight);
        FillTheWallList(transform, walls);
        DeterminateColor(walls);
    }
    private void ReviewWalls()
    {
        _wallPositions = new WallsPieceStats();
        if (_wallPositions.yAaxisStartPositions.ContainsKey(index))
        {
            DestroyWallsChildren();
            ReBuildingWalls(_isRightWall, index);
            index++;
        }
        else return;
    }
    private void ReBuildingWalls(bool isrightWall, int index)
    {
        if (isrightWall)
        {
            GameObject firstObj = Instantiate(_wallPiece, new Vector3(_wallPositions.GetXAxis(), _wallPositions.yAaxisStartPositions[index]), Quaternion.identity, transform);
            firstObj.transform.localScale = new Vector3(firstObj.transform.localScale.x, _wallPositions.yScale[index]);
            for (int i = 1; i < index; i++)
            {
                // Получаем позицию и масштаб предыдущего объекта
                Vector3 previousPosition = firstObj.transform.position;
                Vector3 previousScale = firstObj.transform.localScale;

                // Вычисляем позицию и масштаб следующего объекта
                Vector3 newPosition = new Vector3(previousPosition.x, previousPosition.y - previousScale.y, previousPosition.z);
                Vector3 newScale = new Vector3(previousScale.x, _wallPositions.yScale[index]);

                // Создаем следующий объект и обновляем ссылку на предыдущий объект
                firstObj = Instantiate(_wallPiece, newPosition, Quaternion.identity, transform);
                firstObj.transform.localScale = newScale;
            }
            FillTheWallList(transform, walls);
            DeterminateColor(walls);
        }
        else
        {
            GameObject firstObj = Instantiate(_wallPiece, new Vector3(-_wallPositions.GetXAxis(), _wallPositions.yAaxisStartPositions[index]), Quaternion.identity, transform);
            firstObj.transform.localScale = new Vector3(firstObj.transform.localScale.x, _wallPositions.yScale[index]);
            for (int i = 1; i < index; i++)
            {
                // Получаем позицию и масштаб предыдущего объекта
                Vector3 previousPosition = firstObj.transform.position;
                Vector3 previousScale = firstObj.transform.localScale;

                // Вычисляем позицию и масштаб следующего объекта
                Vector3 newPosition = new Vector3(previousPosition.x, previousPosition.y - previousScale.y, previousPosition.z);
                Vector3 newScale = new Vector3(previousScale.x, _wallPositions.yScale[index]);

                // Создаем следующий объект и обновляем ссылку на предыдущий объект
                firstObj = Instantiate(_wallPiece, newPosition, Quaternion.identity, transform);
                firstObj.transform.localScale = newScale;
            }
            FillTheWallList(transform, walls);
            DeterminateColor(walls);

        }
    }
    private void DestroyWallsChildren()
    {
        for (int i = 0; i < transform.childCount; i++)
            Destroy(transform.GetChild(i).gameObject);
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
            _circleMove.GetNewColor();
        }
    }
    private void ForLeft()
    {
        if (!_isRightWall)
        {
            DeterminateColor(walls);
            _circleMove.GetNewColor();
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
                colorIndex = UnityEngine.Random.Range(0, 3);
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
