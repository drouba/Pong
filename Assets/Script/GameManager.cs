using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    // variables for sendOff
    [HideInInspector]
    public bool sendOff;
    public bool started;
    public AudioSource startSound;

    // UI Variables
    //pts
    public TextMeshProUGUI playerPtsUI;
    public TextMeshProUGUI cpuPtsUI;
    private int playerPts = 0;
    private int cpuPts = 0;
    //menu
    public Canvas menu;

    // variables to get ball info
    [HideInInspector]
    public GameObject ball;


    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("ball");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (started && !sendOff && Input.GetKeyDown("space"))
        {
            sendOff = true;
        }

        

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

    public void StartGame()
    {
        started = true;
        menu.gameObject.SetActive(false);
        startSound.Play();
    }
}
