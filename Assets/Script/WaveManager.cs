using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public int enemyCount, enemySpawCount;
    [SerializeField] GameObject Shop1, Shop2, Shop3;

    SpawnEnemy SE;
    TurretSpawn TS;

    void Start()
    {
        SE = FindAnyObjectByType<SpawnEnemy>();
        TS = FindAnyObjectByType<TurretSpawn>();
        enemySpawCount = SE.maxCountEnemy;
    }

    void Update()
    {
        StartFirsWave();
        NextWave();
    }

    public bool start;
    void StartFirsWave()
    {
        if (Input.GetKeyDown(KeyCode.Space) && start == false)
        {
            SE.stop = false;
            start = true;
        }
    }

    void NextWave()
    {
        if(enemyCount == enemySpawCount)
        {
            start = false;
            SE.stop = true;
            Shop1.SetActive(true);
            Shop2.SetActive(true);
            Shop3.SetActive(true);
            SE.RegisterMaxCount++;
            SE.maxCountEnemy = SE.RegisterMaxCount;
            enemySpawCount = SE.RegisterMaxCount;
            enemyCount = 0;
        }
    }
}
