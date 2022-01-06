using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColor : MonoBehaviour
{

    // color change variables
    SpriteRenderer sprite;

    // variables for accessing game manager script
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        //set sprite renderer 
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameManager.sendOff)
        {
            //change color everytime the ball hits somthing
            sprite.color = RandomColor();
        }
    }

    private Color32 RandomColor()
    {
        return new Color32(
        (byte)UnityEngine.Random.Range(0, 255), //Red
        (byte)UnityEngine.Random.Range(0, 255), //Green
        (byte)UnityEngine.Random.Range(0, 255), //Blue
        255 //Alpha (transparency)
         );
    }
}
