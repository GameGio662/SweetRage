using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.ShaderData;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI Vita;
    [SerializeField] TextMeshProUGUI EnemyCount;



    [SerializeField] GameObject Start_;
    [SerializeField] public GameObject Pausa;
    [SerializeField] GameObject End;


    GameManager GM;
    WaveManager WM;
    void Start()
    {
        GM = FindObjectOfType<GameManager>();
        WM = FindObjectOfType<WaveManager>();
    }


    void Update()
    {
        Vita.text = WM.defCount.ToString();
        EnemyCount.text = WM.enemySpawCount.ToString();
    }

    public void Play()
    {
        Start_.SetActive(false);
        GM.gameStatus = GameManager.GameStatus.gameRunning;
        SceneManager.LoadScene("MainScena", LoadSceneMode.Single);
    }


    public void Continue()
    {
        GM.gameStatus = GameManager.GameStatus.gameRunning;
        Pausa.SetActive(false);
    }

    public void Restart()
    {
        GM.gameStatus = GameManager.GameStatus.gamePaused;
        SceneManager.LoadScene("Start", LoadSceneMode.Single);
    }


    public void Exit()
    {
        Application.Quit();
    }
}
