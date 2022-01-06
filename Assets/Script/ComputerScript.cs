using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerScript : MonoBehaviour
{
    // movement variables
    public Transform ball;
    public float speed = 5f;

    //boundary variables
    private float offset = 0.35f;
    private Vector2 screenBounds;


    // sound variables
    public AudioSource hitSound;

    // variables for accessing game manager script
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        //set boundaries to screen 
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed * (ball.position.y - transform.position.y));

        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + offset, screenBounds.x - offset);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + offset, screenBounds.y - offset);
        transform.position = viewPos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        //play hit sound
        hitSound.Play();
    }

}
