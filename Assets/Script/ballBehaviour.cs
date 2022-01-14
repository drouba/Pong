using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{

    // movement variables
    public float ballSpeed = 1.2f;
    private Vector2 vectMov = Vector2.right;
    private bool towardsCpu = true;
    //public GameObject player;
    //public GameObject cpu;

    // variables for accessing game manager script
    public GameManager gameManager;



    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.started)
            return;
        if(!gameManager.sendOff)
            transform.position = new Vector3 (GameObject.FindGameObjectWithTag("Player").transform.position.x +0.2f, GameObject.FindGameObjectWithTag("Player").transform.position.y, transform.position.z);

        else
            MoveBall();

        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            towardsCpu = true;
            vectMov = Vector2.right + Vector2.up * (collision.contacts[0].point.y - collision.transform.position.y);
        }
        if (collision.gameObject.CompareTag("Cpu"))
        {
            towardsCpu = false;
            vectMov = Vector2.right + Vector2.up * (collision.contacts[0].point.y - collision.transform.position.y);
        }

        if (collision.gameObject.CompareTag("Top") || collision.gameObject.CompareTag("Bottom"))
        {
            vectMov = Vector2.right + new Vector2 (0, vectMov.y) * -1;
        }

        if (collision.gameObject.CompareTag("playerBack"))
        {
            Debug.Log("Game Over");
            reset();
            if (!GameManager.instance.isOnline)
                GameManager.instance.UpdateCpuScore();
            else
                OnlineManager.instance.UpdatePlayer1Pts();

        }
            
        if (collision.gameObject.CompareTag("cpuBack"))
        {
            Debug.Log("Win!");
            reset();
            if(!GameManager.instance.isOnline)
                GameManager.instance.UpdatePlayerScore();
            else
                OnlineManager.instance.UpdatePlayer2Pts();

        }
            
    }

    private void MoveBall()
    {
        if (towardsCpu)
        {
            transform.Translate(vectMov * Time.deltaTime * ballSpeed * gameManager.difficulty);
        }
        else
        {
            transform.Translate(vectMov * Time.deltaTime * ballSpeed * gameManager.difficulty * -1);
        }



    }



    private void reset()
    {
        gameManager.sendOff = false;
        towardsCpu = true;
    }

}
