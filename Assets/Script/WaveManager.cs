using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveManager : MonoBehaviour
{
    [HideInInspector] public int enemyCount, enemySpawCount, defCount;
    [SerializeField] GameObject Tutorial, Space, Shop1, Shop2, Shop3;

    GameManager GM;
    SpawnEnemy SE;

    void Start()
    {
        GM = FindAnyObjectByType<GameManager>();
        SE = FindAnyObjectByType<SpawnEnemy>();
        enemySpawCount = SE.maxCountEnemy;

        defCount = 3;
    }

    void Update()
    {
        Debug.Log(countLevel);
        if (GM.gameStatus == GameManager.GameStatus.gameRunning)
        {
            StartFirsWave();
            NextWave();
            GameOver();
            End();
        }

    }

    public bool start;
    void StartFirsWave()
    {
        if (Input.GetKeyDown(KeyCode.Space) && start == false)
        {
            SE.stop = false;
            start = true;
            Space.SetActive(false);
            Tutorial.SetActive(false);
        }
    }

    int countLevel;
    void NextWave()
    {
        if (enemySpawCount == 0)
        {
            start = false;
            SE.stop = true;
            Space.SetActive(false);
            Shop1.SetActive(true);
            Shop2.SetActive(true);
            Shop3.SetActive(true);
            SE.RegisterMaxCount += 3;
            SE.timerSpawner -= 1.5f;
            SE.maxCountEnemy = SE.RegisterMaxCount;
            enemySpawCount = SE.RegisterMaxCount;
            defCount = 3;
            countLevel++;
        }
    }

    void GameOver()
    {
        if (defCount == 0)
        {
            SceneManager.LoadScene("Start", LoadSceneMode.Single);
        }
    }


    void End()
    {
        if (countLevel == 3)
        {

        }
    }
}
