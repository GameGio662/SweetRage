using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    float speed, vita;
    Transform target;
    int waypointIndex, enemyType;

    private void Start()
    {
        enemyType = Random.Range(0, 3);

        target = WayPointManager.points[0];
    }


    private void Update()
    {

        TypeEnemy(enemyType);
        MoveEnemy();

    }

    void MoveEnemy()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            NextWayPoint();
        }
    }

    private void NextWayPoint()
    {
        waypointIndex++;
        target = WayPointManager.points[waypointIndex];

        if (waypointIndex >= WayPointManager.points.Length - 1)
        {
            Destroy(gameObject);
        }
    }

    private void TypeEnemy(int n)
    {
        switch (n)
        {
            case 0:
                Normal(vita, speed);
                break;
            case 1:
                Veloce(vita, speed);
                break;
            case 2:
                Tank(vita, speed);
                break;
        }
    }
    void Normal(float _vita, float _speed)
    {
        _vita = 4;
        _speed = 2f;

        speed = _speed;
        vita = _vita;
        gameObject.name = "Normal";
    }


    void Veloce(float _vita, float _speed)
    {
        _vita = 3;
        _speed = 3.5f;

        speed = _speed;
        vita = _vita;
        gameObject.name = "Runner";
    }


    void Tank(float _vita, float _speed)
    {
        _vita = 6;
        _speed = 1;

        speed = _speed;
        vita = _vita;
        gameObject.name = "Tank";
    }



}
