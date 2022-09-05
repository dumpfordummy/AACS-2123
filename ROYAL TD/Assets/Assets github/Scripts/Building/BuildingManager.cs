using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    [SerializeField] private List<BuildingTypeSO> activeBuildingType;
    private PathNode townhallNode;
    private GridBase<PathNode> grid = GridHandler.grid;
    private int typeOfTower = 0;

    private void Start()
    {
        townhallNode = grid.GetGridObject(GameObject.Find("/TownHall").GetComponent<Transform>().position);
        townhallNode.isOccupied = true;
        Pathfinding.obstacleList.Add(townhallNode);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            typeOfTower = (typeOfTower == 1) ? 0 : 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            typeOfTower = (typeOfTower == 2) ? 0 : 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            typeOfTower = (typeOfTower == 3) ? 0 : 3;
        }

        if(typeOfTower == 0)
        {
            ResetButtonPosition(tower1: true, tower2: true, tower3: true);
        }
        else if (typeOfTower == 1)
        {
            GameObject.FindGameObjectWithTag("Tower1Button").GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(65, 55, 0);
            ResetButtonPosition(tower2: true, tower3: true);
        }
        else if(typeOfTower == 2)
        {
            GameObject.FindGameObjectWithTag("Tower2Button").GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(185, 55, 0);
            ResetButtonPosition(tower1: true, tower3: true);
        }
        else if(typeOfTower == 3)
        {
            GameObject.FindGameObjectWithTag("Tower3Button").GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(305, 55, 0);
            ResetButtonPosition(tower1: true, tower2: true);
        }

        if (Input.GetMouseButtonDown(0) && typeOfTower != 0)
            PlaceBuilding();
    }

    private void PlaceBuilding()
    {
        PathNode currentNode;
        GridBase<PathNode>.GetXY(GridBase<PathNode>.GetMouseWorldPosition(), out int posX, out int posY);
        currentNode = Pathfinding.GetNode(posX, posY);
        if (!Pathfinding.obstacleList.Contains(currentNode))
        {
            Instantiate(activeBuildingType[typeOfTower].prefab, grid.GetWorldPosition(posX, posY) + offsetBuildCorrection(), Quaternion.identity);
            Pathfinding.obstacleList.Add(currentNode);
        }
        typeOfTower = 0;
    }

    private void ResetButtonPosition(bool? tower1 = false, bool? tower2 = false, bool? tower3 = false)
    {
        if(tower1 == true)
        {
            GameObject.FindGameObjectWithTag("Tower1Button").GetComponent<RectTransform>().localPosition = Vector3.zero;
        }

        if (tower2 == true)
        {
            GameObject.FindGameObjectWithTag("Tower2Button").GetComponent<RectTransform>().localPosition = Vector3.zero;
        }

        if (tower3 == true)
        {
            GameObject.FindGameObjectWithTag("Tower3Button").GetComponent<RectTransform>().localPosition = Vector3.zero;
        }
    }

    private Vector3 offsetBuildCorrection()
    {
        return new Vector3(0.5f, 0.75f);
    }
}
