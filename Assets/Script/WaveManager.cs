using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    float timer;
    SpawnEnemy SE;

    void Start()
    {
        SE = FindAnyObjectByType<SpawnEnemy>();
    }

    void Update()
    {
        StartFirsWave();
    }

    bool start;
    void StartFirsWave()
    {
        if (Input.GetKeyDown(KeyCode.Space) && start == false) 
        {
            SE.stop = false;
            start = true;
        }
    }
}
