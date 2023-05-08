using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] public int maxCountEnemy;
    [SerializeField] public float timerSpawner;
    [HideInInspector] public bool stop;
    [HideInInspector] public int RegisterMaxCount;
    float timer;

    [SerializeField] GameObject Enemy;

    GameManager GM;

    void Start()
    {
        GM = FindAnyObjectByType<GameManager>();


        RegisterMaxCount = maxCountEnemy;
        stop = true;
        timer = timerSpawner;
    }

    void Update()
    {
        if (GM.gameStatus == GameManager.GameStatus.gameRunning)
            Spawn();
    }

    void Spawn()
    {
        timer += Time.deltaTime;
        if (timer > timerSpawner && maxCountEnemy > 0 && stop == false)
        {
            GameObject pos = Instantiate(Enemy);
            pos.transform.position = transform.position;
            timer = 0;
            maxCountEnemy--;
        }
    }
}
