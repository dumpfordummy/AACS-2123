using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    [SerializeField] private List<BuildingTypeSO> activeBuildingType;
    private PathNode townhallNode;
    private GridBase<PathNode> grid = GridHandler.grid;
    private int typeOfTower = 0;
    private woodResources woodResouce;
    private stoneResources stoneResource;
    private GameObject unlockTower1;
    private GameObject unlockTower2;
    private GameObject unlockTower3;
    private GameObject unlockStoneWall;

    private void Start()
    {
        townhallNode = grid.GetGridObject(GameObject.Find("/TownHall").GetComponent<Transform>().position);
        townhallNode.isOccupied = true;
        Pathfinding.obstacleList.Add(townhallNode);
        woodResouce = GameObject.FindGameObjectWithTag("WoodResources").GetComponent<woodResources>();
        stoneResource = GameObject.FindGameObjectWithTag("StoneResources").GetComponent<stoneResources>();
        unlockTower1 = GameObject.FindGameObjectWithTag("UnlockTower1");
        unlockTower2 = GameObject.FindGameObjectWithTag("UnlockTower2");
        unlockTower3 = GameObject.FindGameObjectWithTag("UnlockTower3");
        unlockStoneWall = GameObject.FindGameObjectWithTag("UnlockStoneWall");
    }

    void Update()
    {
        if (woodResouce.getWoodQty() >= 10 && stoneResource.getStoneQty() >= 30)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                typeOfTower = (typeOfTower == 1) ? 0 : 1;
            }
            unlockTower1.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
        }
        else
            unlockTower1.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

        if (woodResouce.getWoodQty() >= 20 && stoneResource.getStoneQty() >= 40)
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                typeOfTower = (typeOfTower == 2) ? 0 : 2;
            }
            unlockTower2.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
        }
        else
            unlockTower2.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

        if (woodResouce.getWoodQty() >= 20 && stoneResource.getStoneQty() >= 40)
        {
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                typeOfTower = (typeOfTower == 3) ? 0 : 3;
            }
            unlockTower3.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
        }
        else
            unlockTower3.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

        if (woodResouce.getWoodQty() >= 5 && stoneResource.getStoneQty() >= 10)
        {
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                typeOfTower = (typeOfTower == 4) ? 0 : 4;
            }
            unlockStoneWall.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
        }
        else
            unlockStoneWall.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);


        if (typeOfTower == 0)
        {
            ResetButtonPosition(tower1: true, tower2: true, tower3: true, tower4: true);
        }
        else if (typeOfTower == 1)
        {
            GameObject.FindGameObjectWithTag("Tower1Button").GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(65, 55, 0);
            ResetButtonPosition(tower2: true, tower3: true, tower4: true);
        }
        else if(typeOfTower == 2)
        {
            GameObject.FindGameObjectWithTag("Tower2Button").GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(185, 55, 0);
            ResetButtonPosition(tower1: true, tower3: true, tower4: true);
        }
        else if(typeOfTower == 3)
        {
            GameObject.FindGameObjectWithTag("Tower3Button").GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(305, 55, 0);
            ResetButtonPosition(tower1: true, tower2: true, tower4: true);
        }
        else if (typeOfTower == 4)
        {
            GameObject.FindGameObjectWithTag("StoneWallButton").GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(425, 55, 0);
            ResetButtonPosition(tower1: true, tower2: true, tower3: true);
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

            if(typeOfTower == 1)
            {
                GameObject.FindGameObjectWithTag("WoodResources").GetComponent<woodResources>().decWoddQty(10);
                GameObject.FindGameObjectWithTag("StoneResources").GetComponent<stoneResources>().decStoneQty(30);
            }
            else if (typeOfTower == 2)
            {
                GameObject.FindGameObjectWithTag("WoodResources").GetComponent<woodResources>().decWoddQty(10);
                GameObject.FindGameObjectWithTag("StoneResources").GetComponent<stoneResources>().decStoneQty(30);
            }
            else if (typeOfTower == 3)
            {
                GameObject.FindGameObjectWithTag("WoodResources").GetComponent<woodResources>().decWoddQty(10);
                GameObject.FindGameObjectWithTag("StoneResources").GetComponent<stoneResources>().decStoneQty(30);
            }
            else if (typeOfTower == 4)
            {
                GameObject.FindGameObjectWithTag("WoodResources").GetComponent<woodResources>().decWoddQty(5);
                GameObject.FindGameObjectWithTag("StoneResources").GetComponent<stoneResources>().decStoneQty(10);
            }
        }
        typeOfTower = 0;
    }

    private void ResetButtonPosition(bool? tower1 = false, bool? tower2 = false, bool? tower3 = false, bool? tower4 = false)
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

        if (tower4 == true)
        {
            GameObject.FindGameObjectWithTag("StoneWallButton").GetComponent<RectTransform>().localPosition = Vector3.zero;
        }
    }

    private Vector3 offsetBuildCorrection()
    {
        return new Vector3(0.5f, 0.75f);
    }
}
