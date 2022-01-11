using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    //menu
    public Canvas menu;

    // game selection, start and end variables
    public AudioSource startSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TwoPlayerLocal()
    {
        SceneManager.LoadScene("2PlayerLocal");
    }

    public void TwoplayerOnline()
    {
        SceneManager.LoadScene("LoadingScene");
    }

    public void LoadSinglePlayer(string gameType)
    {
        SceneManager.LoadScene(gameType);
    }

    





}


