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
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ashot")
        {
            scoring.lives--;
            if (scoring.lives == 0)
            {
                Destroy(other.gameObject);
                gamestate.state = gamestate.GameState.GameOver;
            }
        }
    }
}
