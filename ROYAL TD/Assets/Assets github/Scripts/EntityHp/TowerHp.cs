using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerHp : MonoBehaviour
{
    public static event Action OnTownHallDestroy;
    [SerializeField] private float maxHp;
    [SerializeField] private float currentHp;
    public TowerHpBar hpBar;
    public static bool isInitializing = false;
    private static bool isTownhallImmortal = false;

    private void Start()
    {
        currentHp = maxHp;
        hpBar.setMaxHealth(maxHp);
    }

    public static void ToggleTownhallImmortal()
    {
        isTownhallImmortal = !isTownhallImmortal;
        if (isTownhallImmortal)
        {
            GameObject.Find("Town_Hall_HP/Filler").GetComponent<Image>().color = new Color32(40, 40, 200, 200);
        }
        else
        {
            GameObject.Find("Town_Hall_HP/Filler").GetComponent<Image>().color = new Color32(113, 209, 40, 175);
        }
        
    }

    public void SetCurrentHp(float hp)
    {
        currentHp = hp;
    }

    public void DecreaseEntityHp(Transform enemy, float hpToDecrease)
    {
        if (name == "TownHall" && isTownhallImmortal)
            return;

        currentHp -= hpToDecrease;

        if (currentHp <= 0)
        {
            if (name == "TownHall")
            {
                currentHp = 0;
                OnTownHallDestroy?.Invoke();
            }
            CleanUp(enemy);
            Destroy(gameObject);
        }

        hpBar.setHealth(currentHp);
    }

    public void CleanUp(Transform enemy)
    {
        isInitializing = true;
        if (Pathfinding.obstacleList == null)
        {
            // THIS IS THE END OF GAME
            return;
        }
        foreach (PathNode node in Pathfinding.obstacleList)
        {
            GridBase<PathNode>.GetXY(GetComponent<Transform>().position, out int x, out int y);
            if (node.x == x && node.y == y)
            {
                Pathfinding.obstacleList.Remove(node);
                break;
            }
        }

        enemy.gameObject.GetComponent<EnemyMovement>().InitializeMovement();

        if (TryGetComponent<TowerAttack>(out var target))
        {
            target.target = null;
        }

        isInitializing = false;
    }
}
