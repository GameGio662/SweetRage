using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    WaveManager WM;

    float speed, vita;
    Transform target;
    int waypointIndex, enemyType;

    private void Start()
    {
        WM = FindAnyObjectByType<WaveManager>();

        enemyType = Random.Range(0, 3);
        TypeEnemy(enemyType);
        target = WayPointManager.points[0];
    }


    private void Update()
    {
        MoveEnemy();

        if(vita <= 0)
        {
            Destroy(gameObject);
            WM.enemyCount++;
        }
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
            WM.enemyCount++;
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
        _vita = 8;
        _speed = 2f;

        speed = _speed;
        vita = _vita;
        gameObject.name = "Normal";
    }


    void Veloce(float _vita, float _speed)
    {
        _vita = 5;
        _speed = 3.5f;

        speed = _speed;
        vita = _vita;
        gameObject.name = "Runner";
    }


    void Tank(float _vita, float _speed)
    {
        _vita = 10;
        _speed = 1;

        speed = _speed;
        vita = _vita;
        gameObject.name = "Tank";
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ball")
        {
            vita -= 1;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "IceBall")
        {
            vita -= 2;
            speed = 1;
            Destroy(other.gameObject);
        }
    }

}
