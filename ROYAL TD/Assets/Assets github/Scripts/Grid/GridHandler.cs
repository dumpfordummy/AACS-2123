using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridHandler : MonoBehaviour
{
    private GridBase gridBase;
    void Start()
    {
        GridBase grid = new GridBase(98, 54, 1, new Vector3(-45,-28));
    }

    void Update()
    {

    }

    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        vec.z = 0f;
        return vec;
    }
}
