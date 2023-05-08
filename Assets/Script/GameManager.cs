using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameStatus
    {
        gamePaused,
        gameRunning,
        gameEnd,
        gameStart,
    }

    public GameStatus gameStatus = GameStatus.gameRunning;

    UIManager UI;

    void Update()
    {
        if (UI == null)
            UI = FindObjectOfType<UIManager>();

        if (Input.GetKeyDown("escape") && gameStatus == GameStatus.gameRunning)
        {
            gameStatus = GameStatus.gamePaused;
            UI.Pausa.SetActive(true);
        }
        else if (Input.GetKeyDown("escape") && gameStatus == GameStatus.gamePaused)
        {
            gameStatus = GameStatus.gameRunning;
            UI.Pausa.SetActive(false);
        }
    }

    public void EndGame()
    {
        gameStatus = GameStatus.gameEnd;
    }
}
