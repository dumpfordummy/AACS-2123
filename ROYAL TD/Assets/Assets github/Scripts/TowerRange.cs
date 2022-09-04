using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRange : MonoBehaviour
{
    private TowerAttack parent;

    // Start is called before the first frame update
    void Start()
    {
        parent = GetComponentInParent<TowerAttack>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            parent.target = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            parent.target = null;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(Wait());
            parent.target = other.transform;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
    }
}
