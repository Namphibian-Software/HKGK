using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ship : MonoBehaviour
{
    // Start is called before the first frame update
    public float shipSpeed;
    public float screenBoundary;
    public GameObject shot;
    public alienfactoryscript alienfactory;
    public float deathtimer;
    void Start()
    {
        transform.position = new Vector3(0, -2.8f,5);
    }
   
    // Update is called once per frame
    void ShipControl()
    {
 
        if (Input.GetKey("right"))
        {
            transform.Translate(-shipSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("left"))
        {
            transform.Translate(shipSpeed * Time.deltaTime, 0, 0);
        }
        
        if (transform.position.x < -screenBoundary)
            transform.position=new Vector3(  -screenBoundary,-2.8f,5);
        if (transform.position.x > screenBoundary)
            transform.position= new Vector3(  screenBoundary,-2.8f,5);
        if (Input.GetKeyDown("space"))
        {
            Instantiate(
            shot,
            new Vector3(transform.position.x, transform.position.y, 5),
            Quaternion.identity
            );
        }
    }
    private void Update()
    {
        if (gamestate.state == gamestate.GameState.GamePlay)
        {
            ShipControl();
        }
        if (gamestate.state == gamestate.GameState.StartingPlay)
        {
            alienfactory.MakeAlien();
            gamestate.state = gamestate.GameState.GamePlay;
        }
        if (gamestate.state == gamestate.GameState.Dying)
        {
            transform.Rotate(0, 0, Time.deltaTime * 400.0f);
            deathtimer -= 0.1f;
            if (deathtimer < 5.0)
            {
                GetComponent<Renderer>().enabled = false;
            }
            if (deathtimer < 0)
            {
                gamestate.state = gamestate.GameState.GamePlay;
                transform.position = new Vector3(0.0f, -2.8f, 5f);
                transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 0, transform.rotation.w);

                GetComponent<Renderer>().enabled = true;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (gamestate.state == gamestate.GameState.GamePlay)
            if (other.tag == "ashot")
            {
            scoring.lives--;
                deathtimer = 10.0f;
                gamestate.state = gamestate.GameState.Dying;
                if (scoring.lives == 0)
                {
                    Destroy(other.gameObject);
                    gamestate.state = gamestate.GameState.GameOver;
                }
            }
    }
}
