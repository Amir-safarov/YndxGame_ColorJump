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
    private WallsPieceStats _wallPositions = new WallsPieceStats();
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
            ReBuildingWalls();
            print("Right check");
        }
        if (!_isRightWall && (bounced == 6 || bounced == 10 || bounced ==16))
        {
            ReBuildingWalls();
            print("Left check");
            if (bounced == 6)
                GlobalVariables.wallRank++;
        }
        print($"{GlobalVariables.wallRank}");
    }


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
        //print($"Upgrade with {GlobalVariables.wallRank} picese");
        Transform childTransform = transform.GetChild(0);
        childTransform.position = new Vector3(childTransform.position.x, _wallPositions.yAaxisStartPositions[GlobalVariables.wallRank]);
        childTransform.localScale = new Vector3(childTransform.localScale.x, _wallPositions.yScale[GlobalVariables.wallRank]);

        for (int i = 1; i < GlobalVariables.wallRank; i++)
        {
            Transform nextChild = transform.GetChild(i);
            nextChild.position = new Vector3(transform.GetChild(i - 1).position.x, transform.GetChild(i - 1).position.y - transform.GetChild(i - 1).localScale.y);
            nextChild.localScale = new Vector3(transform.GetChild(i - 1).localScale.x, transform.GetChild(i - 1).localScale.y);
            //currentTransform.position = new Vector3(currentTransform.position.x, currentTransform.position.y - currentTransform.localScale.y, currentTransform.position.z);
        }
    }

    private void DestroyWallsChildren()
    {
        _determinationColor.cleare();
        for (int i = 0; i < transform.childCount; i++)
            Destroy(transform.GetChild(i).gameObject);
        transform.DetachChildren();

    }


}
