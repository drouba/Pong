using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // movement variables
    private float verticalInput;
    public float speed = 5f;
    private float offset = 0.35f;

    // boundary variables
    private Vector2 screenBounds;


    // sound variables
    public AudioSource hitSound;

    public bool isMine = false;


    // Start is called before the first frame update
    void Start()
    {
        // set boundaries
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if(isMine)
            MovePlayer();



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (GameManager.instance.sendOff && collision.gameObject.CompareTag("ball"))
        {
            //play hit sound
            hitSound.Play();
        }
            
    }

    void MovePlayer()
    {
        //player input
        verticalInput = Input.GetAxis("Vertical");

        // move player
        transform.Translate(Vector2.up * Time.deltaTime * speed * verticalInput);

        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + offset, screenBounds.x - offset);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + offset, screenBounds.y - offset);
        transform.position = viewPos;
    }

}
