using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distance = 70 * Time.deltaTime;


        if (dir.magnitude <= distance)
        {
            return;
        }

        transform.Translate(dir.normalized * distance, Space.World);
    }

}
