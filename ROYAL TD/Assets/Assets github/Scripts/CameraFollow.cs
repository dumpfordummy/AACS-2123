using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//let camera follow target
public class CameraFollow : MonoBehaviour
{
    internal static Transform target;
    public float lerpSpeed = 1.0f;

    private GameObject player;
    private Vector3 offset;

    private Vector3 targetPos;

    private void Start()
    {
        if (target == null) return;

        offset = transform.position - target.position;
    }

    private void Update()
    {
        if ((player = GameObject.FindGameObjectWithTag("Player")) != null)
        {
            target = player.GetComponent<Transform>();
            targetPos = target.position + offset;
            Vector3 lerp = Vector3.Lerp(transform.position, targetPos, lerpSpeed * Time.deltaTime);
            transform.position = new Vector3(lerp.x, lerp.y, -10);
        }

        
    }

}

