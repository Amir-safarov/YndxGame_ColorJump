using System;
using UnityEngine;
using UnityEngine.Events;

public class UpgradeWalls : MonoBehaviour
{
    [SerializeField] private bool _isRightWall;
    [SerializeField] private PlayerChangeColor _player;
    [SerializeField] private GameObject _wallPiece;
    [SerializeField] private DeterminationColorsForWalls _determinationColor;

    private bool beforeUp = true;

    private void Awake()
    {
        GlobalEventManager.OnBouncedCountReached.AddListener(ReviewWalls);
    }

    public void ReviewWalls(int bounced)
    {
        if (_isRightWall && (bounced == 5 || bounced == 11 || bounced ==15))
        {
            if (beforeUp || bounced == 15)
            {
                GlobalVariables.wallRank++;
                beforeUp = false;
            }
            RebuildingWalls();
        }
        if (!_isRightWall && (bounced == 6 || bounced == 10 || bounced ==16))
        {
            RebuildingWalls();
            if (bounced == 6)
                GlobalVariables.wallRank++;
        }
        print($"{GlobalVariables.wallRank}");
    }

    private void RebuildingWalls()
    {
        Transform childTransform = transform.GetChild(0);
        childTransform.position = new Vector3(childTransform.position.x, WallsPieceStats.yAaxisStartPositions[GlobalVariables.wallRank]);
        childTransform.localScale = new Vector3(childTransform.localScale.x, WallsPieceStats.yScale[GlobalVariables.wallRank]);

        for (int i = 1; i < GlobalVariables.wallRank; i++)
        {
            Transform nextChild = transform.GetChild(i);
            nextChild.position = new Vector3(transform.GetChild(i - 1).position.x, transform.GetChild(i - 1).position.y - transform.GetChild(i - 1).localScale.y);
            nextChild.localScale = new Vector3(transform.GetChild(i - 1).localScale.x, transform.GetChild(i - 1).localScale.y);
        }
    }
}
