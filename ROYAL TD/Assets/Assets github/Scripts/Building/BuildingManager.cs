using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    [SerializeField] private List<BuildingTypeSO> activeBuildingType;
    private GridBase<PathNode> grid = GridHandler.grid;
    private int typeOfTower = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            typeOfTower = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            typeOfTower = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            typeOfTower = 3;
        }

        if(typeOfTower == 0)
        {
            GameObject.FindGameObjectWithTag("Tower1Button").GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
            GameObject.FindGameObjectWithTag("Tower2Button").GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
            GameObject.FindGameObjectWithTag("Tower3Button").GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        }
        else if (typeOfTower == 1)
        {
            GameObject.FindGameObjectWithTag("Tower1Button").GetComponent<RectTransform>().localPosition = Input.mousePosition;
        }
        else if(typeOfTower == 2)
        {
            GameObject.FindGameObjectWithTag("Tower2Button").GetComponent<RectTransform>().localPosition = Input.mousePosition;
        }
        else if(typeOfTower == 3)
        {
            GameObject.FindGameObjectWithTag("Tower3Button").GetComponent<RectTransform>().localPosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonDown(0))
            PlaceBuilding();
    }

    private void PlaceBuilding()
    {
        PathNode currentNode;
        grid.GetXY(GridBase<PathNode>.GetMouseWorldPosition(), out int posX, out int posY);
        currentNode = Pathfinding.GetNode(posX, posY);
        if (!Pathfinding.obstacleList.Contains(currentNode))
        {
            Instantiate(activeBuildingType[typeOfTower].prefab, grid.GetWorldPosition(posX, posY) + offsetBuildCorrection(), Quaternion.identity);
            Pathfinding.obstacleList.Add(currentNode);
        }
        typeOfTower = 0;
    }

    private Vector3 offsetBuildCorrection()
    {
        return new Vector3(0.5f, 0.75f);
    }
}
