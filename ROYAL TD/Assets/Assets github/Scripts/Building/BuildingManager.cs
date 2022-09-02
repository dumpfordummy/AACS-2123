using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class BuildingManager : MonoBehaviour
{
    [SerializeField] private BuildingTypeSO activeBuildingType;
    private GridBase<PathNode> grid = GridHandler.grid;


    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            PlaceBuilding();
        }
    }

    private void PlaceBuilding()
    {
        PathNode currentNode;
        grid.GetXY(UtilsClass.GetMouseWorldPosition(), out int posX, out int posY);
        currentNode = Pathfinding.GetNode(posX, posY);
        Instantiate(activeBuildingType.prefab, grid.GetWorldPosition(posX, posY) + positionBuildCorrection(), Quaternion.identity);
        Pathfinding.obstacleList.Add(currentNode);
    }

    private Vector3 positionBuildCorrection()
    {
        return new Vector3(0.5f, 0.75f);
    }
}
