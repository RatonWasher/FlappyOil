//Attach this script to the player gO.
//Makes the player jump, rotate, counts points and handles death.
//The jump force, jump sound and linked score text are determinable.

using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class PlayerScript : MonoBehaviour 
{

    private float jumpForce = 15;

    public Text PointsText;
    private int pointsCount = 0;

    private Rigidbody2D PlayerRB;
    private int sens = 1;
    private float randRotation;



    void Start () {
        PlayerRB = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            PlayerRB.velocity = new Vector2(0.0f, jumpForce);
            randRotation = Random.Range(100f, 900f);
            sens *= -1;

            GameObject.FindGameObjectWithTag("GlobalScripts").
                GetComponent<soundsHandler>().play_jumpSound();
        }

        transform.Rotate(new Vector3(0f, 0f, randRotation * sens) * Time.deltaTime);
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        pointsCount++;
        PointsText.text = pointsCount.ToString();
    }


    void OnCollisionEnter2D(Collision2D collider)
    {
        Destroy(gameObject);

        GameObject.Find("GameOverView").GetComponent<GameOverScript>().ShowChildren();

        GameObject.FindGameObjectWithTag("GlobalScripts").
            GetComponent<soundsHandler>().play_deathSound();
    }


    public int getPointsCount()
    {
        return pointsCount;
    }

}
