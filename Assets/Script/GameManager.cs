using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    // variables for sendOff
    [HideInInspector]
    public bool sendOff;

    // game selection, start and end variables
    [HideInInspector]
    public bool started;
    public AudioSource startSound;
    private int gameType; // 1 = single player tournament, 2 = single player survival, 3 = 2 player tournament
    private int ptsToWin = 5;


    // UI Variables
    //pts
    public TextMeshProUGUI playerPtsUI;
    public TextMeshProUGUI cpuPtsUI;
    private int playerPts = 0;
    private int cpuPts = 0;
    //menu
    public Canvas menu;

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

        if (started && !sendOff && Input.GetKeyDown("space"))
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
        started = true;
        menu.gameObject.SetActive(false);
        startSound.Play();
    }

    public void StartSinglePlayerTournament()
    {
        StartGame();
        EnableSinglePlayer();
        gameType = 1;
    }

    public void StartSinglePlayerSurvival()
    {
        StartGame();
        EnableSinglePlayer();
        gameType = 2; 
    }

    public void Start2Player()
    {
        StartGame();
        Enable2Player();
        gameType = 3;
    }

    void EnableSinglePlayer()
    {
        player2.GetComponent<P2Controller>().enabled = false;
        player2.GetComponent<ComputerScript>().enabled = true;
    }
    
    void Enable2Player()
    {
        player2.GetComponent<P2Controller>().enabled = true;
        player2.GetComponent<ComputerScript>().enabled = false;
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
        menu.gameObject.SetActive(true);
        startSound.Play();
        endGame.gameObject.SetActive(false);
        playerWin.gameObject.SetActive(false);
        survivalEnd.gameObject.SetActive(false);
        twoPlayerEnd.gameObject.SetActive(false);
        playerLoose.gameObject.SetActive(false);

    }
}


