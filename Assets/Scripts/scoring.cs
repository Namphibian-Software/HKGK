using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoring : MonoBehaviour
{
    public static int score;
    public static int lives;
    void InitializeGame()
    {
        score = 0;
        lives = 3;
    }
    // Start is called before the first frame update
    void Start()
    {
        InitializeGame(); 
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 90, 30), "Score: " + score);
        GUI.Box(new Rect(Screen.width - 100, 10, 90, 30), "Lives: " + lives);
        if (gamestate.state == gamestate.GameState.PressStart)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 150,
            Screen.height / 2 - 50,
            300, 50), "Click Me to Start"))
            {
                gamestate.state = gamestate.GameState.StartingPlay;
            }
        }
        if (gamestate.state == gamestate.GameState.GameOver)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 200,
            Screen.height / 2 - 50,
            400, 50), "Game Over, Try again"))
            {
                InitializeGame();
                gamestate.state = gamestate.GameState.PressStart;
            }
        }
        // for debugging
        GUI.Box(new Rect(Screen.width / 2 - 30, 10, 90, 30),
        "State: " + gamestate.state);
    }
}
