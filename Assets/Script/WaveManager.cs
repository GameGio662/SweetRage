using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveManager : MonoBehaviour
{
    [HideInInspector] public int maxCount, enemyCount, enemySpawCount, defCount;
    [SerializeField] GameObject Tutorial, Space, Shop1, Shop2, Shop3;
    [HideInInspector] public float speedUp, vitaUp;

    GameManager GM;
    UIManager UM;
    SpawnEnemy SE;
    Base b;
    UIManager UI;

    void Start()
    {
        GM = FindAnyObjectByType<GameManager>();
        SE = FindAnyObjectByType<SpawnEnemy>();
        UM = FindAnyObjectByType<UIManager>();
        b = FindAnyObjectByType<Base>();
        UI = FindAnyObjectByType<UIManager>();
        enemySpawCount = SE.maxCountEnemy;

        if (UI.hardGame == false)
            maxCount = 3;
        win = 3;
        defCount = 3;

        Time.timeScale = 1;
    }

    void Update()
    {
        if (GM.gameStatus == GameManager.GameStatus.gameRunning)
        {
            StartFirsWave();
            Fast();

            if (UI.hardGame == true)
                HardGame();

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

    void Fast()
    {
        if (Input.GetKey(KeyCode.T))
            Time.timeScale = 2;
        else
            Time.timeScale = 1;
    }

    int win;
    void HardGame()
    {
        win = 4;
        maxCount = 4;
    }

    int countLevel;
    void NextWave()
    {
        if (enemySpawCount == 0)
        {
            start = false;
            SE.stop = true;
            Space.SetActive(true);
            Shop1.SetActive(true);
            Shop2.SetActive(true);
            Shop3.SetActive(true);
            speedUp += 1f;
            vitaUp += 1f;
            SE.RegisterMaxCount += 3;
            SE.timerSpawner -= 1f;
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
            SceneManager.LoadScene("MainScena", LoadSceneMode.Single);
        }
    }


    void End()
    {
        if (countLevel == win)
        {
            GM.EndGame();
            UM.End.SetActive(true);
        }
    }
}
