using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    [SerializeField] private BuildingTypeSO activeBuildingType;
    private GridBase<PathNode> grid = GridHandler.grid;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlaceBuilding();
        }
    }

    private void PlaceBuilding()
    {
        PathNode currentNode;
        grid.GetXY(GridBase<PathNode>.GetMouseWorldPosition(), out int posX, out int posY);
        currentNode = Pathfinding.GetNode(posX, posY);
        if (!Pathfinding.obstacleList.Contains(currentNode))
        {
            Instantiate(activeBuildingType.prefab, grid.GetWorldPosition(posX, posY) + offsetBuildCorrection(), Quaternion.identity);
            Pathfinding.obstacleList.Add(currentNode);
        }



    }

    private Vector3 offsetBuildCorrection()
    {
        return new Vector3(0.5f, 0.75f);
    }
}
