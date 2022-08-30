using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//let camera follow target
public class CameraFollow : MonoBehaviour
{
    internal static Transform target;
    public float lerpSpeed = 1.0f;

    private Vector3 offset;

    private Vector3 targetPos;

    private void Start()
    {
        if (target == null) return;

        InitOffset();
    }

    private void Update()
    {
        if (target == null) return;

        targetPos = target.position + offset;
        Vector3 lerp = Vector3.Lerp(transform.position, targetPos, lerpSpeed * Time.deltaTime);
        transform.position = new Vector3(lerp.x, lerp.y, -10);
    }

    internal void InitOffset()
    {
        offset = transform.position - target.position;
    }

}

