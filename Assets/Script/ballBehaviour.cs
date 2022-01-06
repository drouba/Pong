using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballBehaviour : MonoBehaviour
{

    // movement variables
    public float ballSpeed = 0.8f;
    private Vector2 vectMov = Vector2.right;
    private bool towardsCpu = true;
    public GameObject player;
    public GameObject cpu;

    // variables for accessing game manager script
    public GameManager gameManager;



    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if(!gameManager.sendOff )
            transform.position = new Vector3 (player.gameObject.transform.position.x +0.2f, player.gameObject.transform.position.y, transform.position.z);

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
            gameManager.UpdateCpuScore();

        }
            
        if (collision.gameObject.CompareTag("cpuBack"))
        {
            Debug.Log("Win!");
            reset();
            gameManager.UpdatePlayerScore();

        }
            
    }

    private void MoveBall()
    {
        if (towardsCpu)
        {
            transform.Translate(vectMov * Time.deltaTime * ballSpeed);
        }
        else
        {
            transform.Translate(vectMov * Time.deltaTime * ballSpeed * -1);
        }



    }



    private void reset()
    {
        gameManager.sendOff = false;
        towardsCpu = true;
    }

}
