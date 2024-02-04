using System;
using UnityEngine;
using UnityEngine.Events;

public class UpgradeWalls : MonoBehaviour
{
    [SerializeField] private bool _isRightWall;
    [SerializeField] private PlayerChangeColor _player;
    [SerializeField] private GameObject _wallPiece;
    [SerializeField] private DeterminationColorsForWalls _determinationColor;
    public static UpgradeWalls Instance;

    private bool onceUp = true;
    private void Awake()
    {
        GlobalEventManager.OnBouncedCountReached.AddListener(ReviewWalls);
    }

    public void ReviewWalls(int bounced)
    {
        if (_isRightWall && (bounced == 5 || bounced == 15 || bounced == 25))
        {
            if (onceUp)
            {
                GlobalVariables.wallRank++;
                onceUp = false;
            }
            ReBuildingWalls();
            print("Right check");
        }
        if (!_isRightWall && (bounced == 10 || bounced == 20 || bounced == 25))
        {
            ReBuildingWalls();
            print("Left check");
            GlobalVariables.wallRank++;
        }
    }

    private WallsPieceStats _wallPositions;

    /*_wallPositions = new WallsPieceStats();
Debug.Log($"Value before up: {GlobalVariables.wallRank}");
GlobalVariables.wallRank++;
Debug.Log($"Value after up: {GlobalVariables.wallRank}");
if (_wallPositions.yAaxisStartPositions.ContainsKey(GlobalVariables.wallRank))
ReBuildingWalls(_isRightWall);
else return;*/
    private void ReBuildingWalls()
    {
        if (_isRightWall)
            BildUpgrades();
        else
            BildUpgrades();
    }

    private void BildUpgrades()
    {
        print($"Upgrade with {GlobalVariables.wallRank} picese");
        /*transform.GetChild(0).position = new Vector3(transform.GetChild(0).position.x, _wallPositions.yAaxisStartPositions[GlobalVariables.wallRank]);
        transform.GetChild(0).localScale = new Vector3(transform.GetChild(0).localScale.x, _wallPositions.yScale[GlobalVariables.wallRank]);
        for (int i = 1; i < GlobalVariables.wallRank; i++)
        {
            Vector3 previousPosition = new Vector3(transform.GetChild(0).position.x, _wallPositions.yAaxisStartPositions[GlobalVariables.wallRank]); ;
            Vector3 previousScale = new Vector3(transform.GetChild(0).localScale.x, _wallPositions.yScale[GlobalVariables.wallRank]); ;

            Vector3 newPosition = new Vector3(previousPosition.x, previousPosition.y - previousScale.y, previousPosition.z);
            Vector3 newScale = new Vector3(previousScale.x, _wallPositions.yScale[GlobalVariables.wallRank]);

            transform.GetChild(1).position = newPosition;
            transform.GetChild(1).localScale = newScale;
        }*/
    }

    private void DestroyWallsChildren()
    {
        _determinationColor.cleare();
        for (int i = 0; i < transform.childCount; i++)
            Destroy(transform.GetChild(i).gameObject);
        transform.DetachChildren();

    }


}
