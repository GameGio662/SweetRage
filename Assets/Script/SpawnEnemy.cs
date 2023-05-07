using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] public int maxCountEnemy;
    [SerializeField] float timerSpawner;
    [HideInInspector] public bool stop;
    public int RegisterMaxCount;
    float timer;

    [SerializeField] GameObject Enemy;

    void Start()
    {
        RegisterMaxCount = maxCountEnemy;
        stop = true;
        timer = timerSpawner;
    }

    void Update()
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
