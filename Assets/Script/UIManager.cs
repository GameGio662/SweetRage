using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI Vita;
    [SerializeField] TextMeshProUGUI EnemyCount;



    [SerializeField] GameObject Start_;
    [SerializeField] public GameObject Pausa;
    [SerializeField] public GameObject End;


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
    }

    [HideInInspector] public bool hardGame;
    public void Hard()
    {
        Start_.SetActive(false);
        hardGame = true;
        GM.gameStatus = GameManager.GameStatus.gameRunning;
    }

    
    public void Continue()
    {
        GM.gameStatus = GameManager.GameStatus.gameRunning;
        Pausa.SetActive(false);
    }

    public void Restart()
    {
        GM.gameStatus = GameManager.GameStatus.gamePaused;
        SceneManager.LoadScene("MainScena", LoadSceneMode.Single);
    }


    public void Exit()
    {
        Application.Quit();
    }
}
