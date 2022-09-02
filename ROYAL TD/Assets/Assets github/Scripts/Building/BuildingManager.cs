using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class BuildingManager : MonoBehaviour
{
    [SerializeField] private BuildingTypeSO activeBuildingType;
    private GridBase<PathNode> grid;


    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            PlaceBuilding();
        }
    }

    private void PlaceBuilding()
    {
        grid.GetXY(transform.position, out int posX, out int posY);
        Instantiate(activeBuildingType.prefab, new Vector3(posX, posY), Quaternion.identity);

    }
}
