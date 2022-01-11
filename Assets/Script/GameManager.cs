using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    // variables for sendOff
    //[HideInInspector]
    public bool sendOff;

    // game selection, start and end variables
    [HideInInspector]
    public AudioSource startSound;
    public int gameType; // 1 = single player tournament, 2 = single player survival, 3 = 2 player local
    private int ptsToWin = 5;
    public float difficulty = 1;
    public bool started;
    public Canvas diffCanvas;


    // UI Variables
    //pts
    public TextMeshProUGUI playerPtsUI;
    public TextMeshProUGUI cpuPtsUI;
    private int playerPts = 0;
    private int cpuPts = 0;


    // Endgame canvas varaibles
    public GameObject endGame;
    public Canvas playerWin;
    public Canvas playerLoose;
    public Canvas survivalEnd;
    public Canvas twoPlayerEnd;

    // variables to get ball info
    [HideInInspector]
    public GameObject ball;

    // player2 variables 
    private GameObject player2;


    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("ball");
        player2 = GameObject.FindGameObjectWithTag("Cpu");
    }

    // Update is called once per frame
    void Update()
    {

        if (started & !sendOff && Input.GetKeyDown("space"))
        {
            sendOff = true;
        }

        checkEndGame();



    }

    public void UpdatePlayerScore()
    {
        playerPts++;
        playerPtsUI.text = playerPts.ToString();
    }

    public void UpdateCpuScore()
    {
        cpuPts++;
        cpuPtsUI.text = cpuPts.ToString();
    }

    void StartGame()
    {
        diffCanvas.gameObject.SetActive(false);
        started = true;
        startSound.Play();
    }

    public void DifficultySelection()
    {
        diffCanvas.gameObject.SetActive(true);

    }

    public void DiffEasy()
    {
        difficulty = 0.8f;
        StartGame();
    }

    public void DiffMedium()
    {
        difficulty = 1.2f;
        StartGame();
    }

    public void DiffHard()
    {
        difficulty = 1.5f;
        StartGame();
    }



    void checkEndGame()
    {
        switch (gameType)
        {
            case 1:
                if (playerPts == ptsToWin)
                    PlayerWin();
                else if (cpuPts == ptsToWin)
                    CpuWin();
                break;
            case 2:
                if (cpuPts != 0)
                    GameOver();
                break;
            case 3:
                if (playerPts == ptsToWin)
                    Player1Win();
                else if (cpuPts == ptsToWin)
                    Player2Win();
                break;
        }
    }

    void GameEnd()
    {
        started = false;
 
    }

    void ReinitializeScores()
    {
        playerPts = 0;
        playerPtsUI.text = playerPts.ToString();
        cpuPts = 0;
        cpuPtsUI.text = cpuPts.ToString();
    }

    void PlayerWin()
    {
        endGame.gameObject.SetActive(true);
        playerWin.gameObject.SetActive(true);
        GameEnd();
    }

    void CpuWin()
    {
        endGame.gameObject.SetActive(true);
        playerLoose.gameObject.SetActive(true);
        GameEnd();
    }

    void GameOver()
    {
        endGame.gameObject.SetActive(true);
        survivalEnd.gameObject.SetActive(true);
        survivalEnd.transform.Find("EndText").GetComponent<TextMeshProUGUI>().text = "You made " + playerPts + " points";
        GameEnd();
    }

    void Player1Win()
    {
        endGame.gameObject.SetActive(true);
        twoPlayerEnd.gameObject.SetActive(true);
        twoPlayerEnd.transform.Find("winner").GetComponent<TextMeshProUGUI>().text = "Player 1 won!";
        GameEnd();
    }

    void Player2Win()
    {
        endGame.gameObject.SetActive(true);
        twoPlayerEnd.gameObject.SetActive(true);
        twoPlayerEnd.transform.Find("winner").GetComponent<TextMeshProUGUI>().text = "Player 2 won!";
        GameEnd();
    }

    public void ReturnToMain()
    {
        ReinitializeScores();
        startSound.Play();
        SceneManager.LoadScene("Menu");

    }
}


